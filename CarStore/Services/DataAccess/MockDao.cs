using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Models;
using Windows.Devices.Radios;
using Windows.Storage;

namespace CarStore.Services.DataAccess;
public class MockDao : IDao
{
    public List<Car> getAllCars()
    {
        var result = new List<Car>()
        {
            new()
            {
                CarId = 1,
                Name = "Kia Cerato 2018 1.6AT",
                Manufacturer = 2,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 429000000,
                UsageStatus = "mới",
                Images = "Assets\\images\\KiaCerato20181.6AT",
                Variant = "Trắng Đen Đỏ",
                Description = "Động cơ: Kia Cerato 2018 được trang bị động cơ xăng 1.6L, 4 xy-lanh thẳng hàng, " +
                "giúp xe vận hành ổn định với công suất tối đa 128 mã lực và mô-men xoắn cực đại 157 Nm.\r\nHộp số: " +
                "Sử dụng hộp số tự động 6 cấp (1.6AT), Cerato 2018 mang lại trải nghiệm lái mượt mà, đặc biệt phù hợp " +
                "cho việc di chuyển trong thành phố.\r\nNgoại thất: Xe có thiết kế hiện đại với lưới tản nhiệt hình mũi" +
                " hổ đặc trưng, đèn pha LED sắc nét, cùng đèn sương mù giúp tăng khả năng chiếu sáng trong điều kiện thời " +
                "tiết xấu.\r\nNội thất: Nội thất rộng rãi với ghế ngồi bọc da, màn hình giải trí trung tâm 7 inch hỗ trợ kết " +
                "nối Bluetooth, USB và Apple CarPlay. Hệ thống điều hòa tự động hai vùng giúp mang lại sự thoải mái cho cả tài " +
                "xế và hành khách.\r\nAn toàn: Kia Cerato 2018 1.6AT được trang bị hệ thống phanh ABS, EBD, cân bằng điện tử ESP," +
                " cảm biến lùi, camera lùi và 6 túi khí bảo vệ, giúp đảm bảo an toàn tối đa cho người sử dụng.\r\nƯu điểm:\r\n\r\n" +
                "Tiết kiệm nhiên liệu với mức tiêu thụ trung bình khoảng 7-8L/100km.\r\nThiết kế thanh lịch, hiện đại, phù hợp cho " +
                "cả gia đình và công việc.\r\nHệ thống giải trí và điều hòa hiện đại, đáp ứng nhu cầu giải trí và thoải mái khi lái.\r\n" +
                "Nhược điểm:\r\n\r\nKhả năng tăng tốc chưa quá mạnh mẽ, phù hợp hơn với nhu cầu di chuyển trong đô thị và đường bằng phẳng.",
            },

            new()
            {
                CarId = 2,
                Name = "VinFast Fadil 1.4AT 2022",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 2,
                Price = 325000000,
                UsageStatus = "mới",
                Images = "Assets\\images\\VinFastFadil1.4AT2022",
                Variant = "Trắng Đen",
                Description = "Động cơ: Xe trang bị động cơ xăng 1.4L, công suất tối đa đạt 98 mã lực và mô-men " +
                "xoắn cực đại 128 Nm, giúp xe vận hành linh hoạt, đặc biệt phù hợp di chuyển trong đô thị.\r\nHộp " +
                "số: Sử dụng hộp số tự động vô cấp (CVT), xe mang lại trải nghiệm lái êm ái và tiết kiệm nhiên liệu" +
                ", lý tưởng cho việc di chuyển hàng ngày.\r\nNgoại thất: VinFast Fadil 2022 có thiết kế nhỏ gọn, " +
                "hiện đại với lưới tản nhiệt đặc trưng của VinFast, cùng cụm đèn pha LED, đèn hậu LED và đèn sương " +
                "mù cho khả năng chiếu sáng tốt.\r\nNội thất: Nội thất của Fadil 1.4AT tiện nghi với ghế da, vô-lăng " +
                "bọc da tích hợp các phím chức năng, màn hình giải trí 7 inch hỗ trợ kết nối Apple CarPlay, Android Auto" +
                " và hệ thống điều hòa chỉnh cơ.\r\nAn toàn: Xe được trang bị hệ thống phanh ABS, EBD, cân bằng điện tử ESC," +
                " hỗ trợ khởi hành ngang dốc HSA, cảm biến lùi, camera lùi, và 6 túi khí, đảm bảo tiêu chuẩn an toàn cao cấp." +
                "\r\nƯu điểm:\r\n\r\nThiết kế gọn gàng, linh hoạt, rất thích hợp di chuyển trong thành phố.\r\nTrang bị tiện nghi" +
                " và công nghệ an toàn cao so với phân khúc xe hạng A.\r\nKhả năng tiết kiệm nhiên liệu tốt, mức tiêu thụ trung " +
                "bình khoảng 6-7L/100km.\r\nNhược điểm:\r\n\r\nKhông gian nội thất nhỏ, có thể sẽ hạn chế cho người dùng có nhu" +
                " cầu di chuyển xa với nhiều hành lý.\r\nCông suất động cơ vừa phải, phù hợp cho việc di chuyển đô thị hơn là di " +
                "chuyển tốc độ cao.",
            },

            new()
            {
                CarId = 3,
                Name = "Xpander AT Eco 2023",
                Manufacturer = 3,
                EngineType = 1,
                TypeOfCar = 3,
                Price = 565000000,
                UsageStatus = "cũ",
                Images = "Assets\\images\\XpanderATEco2023",
                Variant = "Đen",
                Description="✳️ Option nổi bật của xe.\r\n🔅 Đã lên Camera lùi.\r\n🔅 " +
                "Nội thất nguyên bản từ mới - có sẵn lót sàn.\r\n🔅 Điều hòa 2 vùng + Gương " +
                "chỉnh điện Auto.\r\n🔅 Đăng kiểm dài còn đến 07/2026.\r\n\r\nCam kết:\r\n✅Pháp " +
                "Lý Đảm Bảo, Không đâm đụng, Không ngập nước, Không cháy nổ.\r\n✅Hỗ trợ cho vay trả " +
                "góp lên đến 70%\r\n✅Đội ngũ nhân viên chuyên nghiệp nhiệt tình và chu đáo.\r\n✅Cam " +
                "kết chất lượng theo tiêu chuẩn 207 điểm kiểm định của Chợ Tốt Xe.\r\n✅Lái thử xe ngay," +
                " không cần đặt cọc.\r\n✅Bao kiểm tra tại các xưởng và hãng trên toàn quốc.",
            },

            new()
            {
                CarId = 4,
                Name = "Vinfast Lux SA2.0 2021",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 2,
                Price = 828000000,
                UsageStatus = "mới",
                Images = "Assets\\images\\VinfastLuxSA2.02021",
                Variant = "Trắng Đen",
                Description ="Động cơ: Xe được trang bị động cơ xăng 2.0L tăng áp, 4 xy-lanh, sản " +
                "sinh công suất 228 mã lực và mô-men xoắn cực đại 350 Nm, kết hợp với hệ thống dẫn " +
                "động cầu sau hoặc dẫn động 4 bánh toàn thời gian AWD (tùy phiên bản).\r\nHộp số: Sử " +
                "dụng hộp số tự động 8 cấp ZF, giúp xe chuyển số mượt mà và mang lại cảm giác lái mạnh" +
                " mẽ, ổn định trên nhiều địa hình.\r\nNgoại thất: VinFast Lux SA2.0 2021 có thiết kế " +
                "sang trọng và đậm chất Việt Nam với lưới tản nhiệt hình chữ \"V\" đặc trưng, cụm đèn " +
                "pha LED mỏng kéo dài, đèn sương mù và đèn hậu LED. Xe có kích thước lớn, thiết kế hầm " +
                "hố và mạnh mẽ.\r\nNội thất: Không gian nội thất rộng rãi, bọc da cao cấp, với bảng điều " +
                "khiển trung tâm màn hình cảm ứng 10.4 inch hỗ trợ kết nối Apple CarPlay và Android Auto," +
                " hệ thống âm thanh 8 loa (nâng cấp lên 13 loa ở phiên bản cao cấp). Hàng ghế sau rộng rãi " +
                "và điều hòa tự động 2 vùng giúp mang lại sự thoải mái cho hành khách.\r\nAn toàn: VinFast " +
                "Lux SA2.0 2021 được trang bị nhiều tính năng an toàn như phanh ABS, EBD, hỗ trợ phanh khẩn " +
                "cấp BA, cân bằng điện tử ESC, hỗ trợ đổ đèo HDC, cảnh báo điểm mù, cảm biến trước sau, camera" +
                " 360, và 6 túi khí, đảm bảo an toàn tối đa cho người dùng.\r\nƯu điểm:\r\n\r\nThiết kế sang" +
                " trọng, kích thước lớn, mang lại cảm giác an toàn và vững chãi.\r\nĐộng cơ mạnh mẽ, hộp số 8 " +
                "cấp mượt mà, giúp xe vận hành tốt trên nhiều loại địa hình.\r\nTiện nghi cao cấp, không gian nội" +
                " thất rộng rãi, đầy đủ các tính năng giải trí và kết nối hiện đại.\r\nNhược điểm:\r\n\r\nMức " +
                "tiêu thụ nhiên liệu khá cao, dao động từ 8-10L/100km tùy điều kiện di chuyển.\r\nKích thước lớn " +
                "có thể không phù hợp cho những khu vực đô thị chật hẹp.",
            },
        };

        return result;
    }
    public List<Manufacturer> getAllManufacturer()
    {
        var result = new List<Manufacturer>()
        {
            new()
            {
                Id = 1,
                Name = "Vinfast",
            },

            new()
            {
                Id = 2,
                Name = "Kia",
            },

            new()
            {
                Id = 3,
                Name = "Mitsubishi",
            },
            new()
            {
                Id = 4,
                Name = "Porsche",
            },

        };

        return result;
    }

    public List<EngineType> GetEngineTypes()
    {
        var result = new List<EngineType>()
        {
            new()
            {
                Id = 1,
                Name = "Xăng",
            },
            new()
            {
                Id = 2,
                Name = "Điện",
            },
            new()
            {
                Id = 3,
                Name = "Diesel",
            },
            new()
            {
                Id = 4,
                Name = "Hybrid",
            },
        };

        return result;
    }

    public List<TypeOfCar> GetTypeOfCar()
    {
        var list = new List<TypeOfCar>()
        {
            new()
            {
                Id= 1,
                Name = "Sedan",
            },
            new()
            {
                Id= 2,
                Name = "HatchBack",
            },
            new()
            {
                Id= 3,
                Name = "SUV",
            },
            new()
            {
                Id= 4,
                Name = "CUV",
            },
            new()
            {
                Id= 5,
                Name = "Minivan",
            },
            new()
            {
                Id= 6,
                Name = "Coupe",
            },
            new()
            {
                Id= 7,
                Name = "Canbriolet",
            },
            new()
            {
                Id= 8,
                Name = "Cabriolet",
            },
        };

        return list;
    }
}
