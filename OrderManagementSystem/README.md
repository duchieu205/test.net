# OrderManagementSystem

Hệ thóng quản lí đơn hàng với kiến trúc **Clean Architechture + DDD** sử dụng **.NET 8** và **MySQL**

## Tính năng chính

- Quản lý sản phẩm: thêm mới, xem danh sách
- Quản lý đơn hàng: tạo đơn, xem danh sách, xem chi tiết
- Tự động tính tổng tiền, VAT, grandTotal
- RESTFUL API chuẩn, có SWAGGER UI

## Công nghệ

- **.NET 8**
- **Entity Framework Core**
- **Clean Architecture (API / Application / Domain / Infrastructure)**
- **Domain-Driven Design (DDD)**
- **MySQL**

# Hướng dẫn chạy dự án

1. Clone source code
- git clone https://github.com/duchieu205/test.net
- cd OrderManagement System

2. Khởi tạo database
- dotnet ef database update -p OrderManagement.Infrastructure -s OrderManagement.API

3. Chạy dự án
- dotnet run --project OrderManagement.API

4. Truy cập SWAGGER UI
- Mở trịnh duyệt: https://localhost:5001/swagger

# Test API
- Thêm sản phẩm: POST /api/products
json {
    "productCode": "SP001",
    "name": "IPhone 15",
    "price": 25000000,
    "unit": "cái"
}

- Tạo đơn hàng: POST /api/orders
json {
    {
    "customerName": "Nguyen Van A",
    "items": [
        {
        "productCode": "SP001",
        "productName": "IPhone 15",
        "quantity": 2,
        "unitPrice": 25000000
        }
    ]
}
}

**Danh sách API**

Method     |     Endpoint          |  Chức năng
GET        |     /api/products     |  Lấy danh sách sản phẩm
POST       |     /api/products     |  Tạo sản phẩm mới
POST       |     /api/orders       |  Tạo đơn hàng mới
GET        |     /api.orders       |  Xem tất cả đơn hàng
GET        |     /api.orders/{id}  |  Xem chi tiết đơn hàng

