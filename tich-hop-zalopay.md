# Tích hợp ZaloPay

Chi tiết cách tích hợp Zalo Pay xem [ở đây](https://docs.zalopay.vn/v2/general/overview.html)

## Bước 1: Tạo đơn hàng

- Khi user nhấn nút thanh toán bằng ZaloPay, trên server sẽ gọi sang ZaloPay để khởi tạo đơn hàng.
  - Khởi tạo cần chú ý 1 số thông tin (xem comment trong đoạn code) như:
    - `app_trans_id`
    - `redirecturl`
    - `amount`
- Sau khi khởi tạo thành công, ZaloPay sẽ trả về 1 đường dẫn trong field `order_url`.
- Server sẽ redirect tới đường dẫn trong `order_url`.

```js
// Node v10.15.3
const axios = require('axios').default; // npm install axios
const CryptoJS = require('crypto-js'); // npm install crypto-js
const moment = require('moment'); // npm install moment

const config = {
    app_id: "2554",
    key1: "sdngKKJmqEMzvh5QQcdD2A9XBSKUNaYn",
    endpoint: "https://sb-openapi.zalopay.vn/v2/create"
};

// RedirectURL là đường dẫn tới web mình sau khi thanh toán ZaloPay thành công
const embed_data = {
  "redirecturl": "http://localhost:8080/order/paymentcheck"
};

const items = [{}];

// Có thể thêm order ID vào chuỗi nếu muốn
const transID = Math.floor(Math.random() * 1000000);

// AppTransID cần lưu lại trong đơn hàng dùng để kiểm tra sau khi thanh toán thành công.
// Zalo yêu cầu bắt đầu bằng YYMMDD_ và sau đó là chuỗi gì cũng được.
// Ví dụ: 230304_abc123  => Ngày 4 tháng 3 năm 2023, chuỗi sau bất kỳ.
const appTransID = `${moment().format('YYMMDD')}_${transID}`;

const order = {
    app_id: config.app_id,
    app_trans_id: appTransID,
    app_user: "Bất kỳ tên gì muốn hiển thị (ví dụ: PH-Tech)",
    app_time: Date.now(), // miliseconds
    item: JSON.stringify(items),
    embed_data: JSON.stringify(embed_data),
    amount: 50000,
    description: `Nội dung gì cũng được (ví dụ: Ph-Tech - Payment for the order #12345)`,
    bank_code: "zalopayapp",
};

// appid|app_trans_id|appuser|amount|apptime|embeddata|item
const data = config.app_id + "|" + order.app_trans_id + "|" + order.app_user + "|" + order.amount + "|" + order.app_time + "|" + order.embed_data + "|" + order.item;
order.mac = CryptoJS.HmacSHA256(data, config.key1).toString();

axios.post(config.endpoint, null, { params: order })
    .then(res => {
        console.log(res.data);

        // Redirect tới đường dẫn này để bắt đầu thanh toán ZaloPay
        const resData = JSON.stringify(res.data);
        console.log(resData.order_url);
    })
    .catch(err => console.log(err));
```

## Bước 2: Thanh toán bằng ZaloPay

- Sau khi chuyển trang đến `order_url`, dùng app ZaloPay (test) thanh toán.
- Sau khi thanh toán thành công, Zalo sẽ chuyển ngược lại về `redirecturl`. Lúc này, Zalo sẽ gắn thêm query params vào đường dẫn `redirecturl`. Ví dụ:

    ```html
    http://localhost:8080/order/paymentcheck?apptransid=230304_12345&...
    ```

- Chỉ cần chú ý param `apptransid`. Lấy param này ra và gọi ZaloPay API để kiểm tra xem đơn hàng thanh toán thành công hay chưa.

## Bước 3: Kiểm tra đơn hàng thanh toán thành công chưa

- Sau khi nhận được `apptransid` từ ZaloPay redirect về, gọi Zalo kiểm tra trạng thái đơn hàng.

```js
// Node v10.15.3
const axios = require('axios').default; // npm install axios
const CryptoJS = require('crypto-js'); // npm install crypto-js
const qs = require('qs')

const config = {
    app_id: "2554",
    key1: "sdngKKJmqEMzvh5QQcdD2A9XBSKUNaYn",
    endpoint: "https://sb-openapi.zalopay.vn/v2/query"
};

let postData = {
    app_id: config.app_id,
    app_trans_id: "<app_trans_id>", // Bỏ giá trị apptransid lấy từ query param vào đây
}

let data = postData.app_id + "|" + postData.app_trans_id + "|" + config.key1; // appid|app_trans_id|key1
postData.mac = CryptoJS.HmacSHA256(data, config.key1).toString();

let postConfig = {
    method: 'post',
    url: config.endpoint,
    headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
    },
    data: qs.stringify(postData)
};

axios(postConfig)
    .then(function (response) {
        console.log(response.data);

        const resData = JSON.stringify(response.data);
        const returnCode = resData.return_code;
        const isProcessing = resData.is_processing;

        // Đơn hàng được xem là thành công khi returnCode = 1 và isProcessing = false
        const isOrderSuccess = returnCode == 1 && !isProcessing;
        console.log(isOrderSuccess);
        // 
    })
    .catch(function (error) {
        console.log(error);
    });
```
