# MiniStore MVC5 – Customer Site đến hết Giỏ hàng

Project ASP.NET MVC 5 + Entity Framework 6, triển khai theo slide `Web BE Development_p3 Customer Site`.

## Chức năng đã có đến hết phần Giỏ hàng (3.2)
- Customer Layout dùng chung, menu danh mục lấy từ database, menu tài khoản và số lượng giỏ hàng.
- Đăng ký, đăng nhập, đăng xuất và xem thông tin tài khoản.
- Trang chủ, tìm kiếm sản phẩm, danh sách theo danh mục.
- Sắp xếp và phân trang danh sách sản phẩm.
- Chi tiết sản phẩm và sản phẩm cùng danh mục.
- Giỏ hàng lưu bằng Session thông qua `CartService`.
- Thêm sản phẩm, cập nhật số lượng, xóa từng sản phẩm và xóa toàn bộ giỏ.
- Chọn/bỏ chọn sản phẩm muốn mua và tính tổng tiền các sản phẩm được chọn.
- Giỏ hàng nâng cao: nhóm mặt hàng theo danh mục và hiển thị sản phẩm tương tự.

Các trang đặt hàng/đơn hàng có sẵn trong source ban đầu, nhưng không nằm trong phạm vi hoàn thiện của phần bài này. Thanh toán PayPal không được tích hợp.

## Công nghệ
- ASP.NET MVC 5
- .NET Framework 4.8
- Entity Framework 6
- SQL Server LocalDB / SQL Server Express
- Bootstrap 4

## Mở và chạy bằng Visual Studio 2022
1. Giải nén ZIP.
2. Mở `BE5.sln` bằng Visual Studio 2022.
3. Đảm bảo đã cài workload **ASP.NET and web development** và .NET Framework 4.8 Developer Pack.
4. Mở `Database/MyStore.sql` bằng SQL Server Management Studio hoặc SQL Server Object Explorer và chạy script để tạo database mẫu.
   - Lưu ý: script khởi tạo có lệnh xóa các bảng cùng tên trước khi tạo lại. Không chạy trên database đang chứa dữ liệu cần giữ.
5. Kiểm tra connection string `DefaultConnection` trong `MiniStore/Web.config`. Mặc định dùng `(localdb)\\MSSQLLocalDB`.
6. Restore NuGet packages (right-click Solution > Restore NuGet Packages).
7. Chọn project `MiniStore` làm Startup Project, Build Solution, sau đó nhấn Ctrl+F5.

## Tài khoản mẫu
- Admin: `admin` / `Admin123!`
- Khách hàng: `customer` / `Customer123!`

Đây là tài khoản demo cho bài tập.

## Cấu trúc phần giỏ hàng
- `Models/ViewModel/CartItem.cs`: dữ liệu mỗi sản phẩm trong giỏ.
- `Models/ViewModel/Cart.cs`, `CartVM.cs`: nhóm sản phẩm và tính tổng.
- `Models/ViewModel/CartService.cs`: thao tác giỏ hàng trong Session.
- `Controllers/CartController.cs`: các action giỏ hàng.
- `Views/Cart/Index.cshtml`: giao diện giỏ hàng.
- `Views/Cart/_PVSimilarProduct.cshtml`: sản phẩm tương tự.
- `Controllers/CategoryController.cs`, `Views/Shared/_CategoriesPV.cshtml`: menu danh mục.

## Đẩy lên GitHub
Mở Terminal tại thư mục chứa `BE5.sln` rồi chạy:
```bash
git init
git add .
git commit -m "Complete customer site through shopping cart"
git branch -M main
git remote add origin https://github.com/USERNAME/REPOSITORY.git
git push -u origin main
```
Thay URL bằng repository GitHub của bạn. Không đưa `bin/`, `obj/`, `.vs/` hoặc file `.user` lên GitHub.
