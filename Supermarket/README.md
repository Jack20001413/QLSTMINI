Cài đặt công cụ migration
- dotnet tool install --global dotnet-ef
Tạo database
- Vào appsettings.json -> ConnectionString -> Chỉnh sửa lại tên Server theo tên server của mình -> Server =
- Lấy tên database ở Database = 
- Vào MSSQL tạo database với tên vừa lấy được
Khởi tạo file migration
- dotnet ef migrations add InitialCreate
Cập nhật trong database (Bắt đầu khởi tạo database dựa theo file migration)
- dotnet ef database update

Trường hợp migrate sai - hoặc cần migrate lại 
- Vào MSSQL -> Delete database (chọn option close connection)
- Thực hiện lại bước tạo database -> Khởi tạo migration -> Cập nhật database