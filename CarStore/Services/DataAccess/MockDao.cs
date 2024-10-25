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
                Manufacturer = "Kia",
                EngineType = "Xăng",
                TypeOfCar = "Sedan",
                Price = 429000000,
                UsageStatus = "Xe mới",
                Description = "Kia Cerato 1.6AT 2018 - Odo 48,000km Xe Zin Chuẩn Ko Lỗi.\r\n" +
                              "⭕XEM XE LÁI THỬ TẬN NHÀ KO CẦN CỌC.\r\n" +
                              "1. Biển số: 60A ( Sang tên về TP ko tốn 20tr Biển Số)\r\n" +
                              "2. Odo: 48,300 km chuẩn ( bao test hãng )\r\n" +
                              "3. Động cơ: 1.6 lít ( Tiêu hao 6 - 7l/100km)\r\n" +
                              "4. Hộp số: Số tự động 6 cấp.\r\n" +
                              "5. Phân khúc: Sedan hạng C rộng rãi và tiện nghi.\r\n" +
                              "6. Hỗ trợ đầy đủ dịch vụ Đăng Kí - Đăng Kiểm - Sang Tên toàn Quốc.\r\n\r\n" +
                              "✴️ Tình trạng xe:\r\n♻️ Xe gia đình, Ko chạy dịch vụ.\r\n" +
                              "♻️ Bảo dưỡng định kì đầy đủ.\r\n" +
                              "♻️ Động cơ - hộp số - keo chỉ - gầm bệ nguyên bản chưa qua sửa chữa.\r\n♻️ Ngoại thất màu BẠC. Nước Sơn còn rất mới và liền lạc.\r\n♻️ Nội thất ghế da zin sạch đẹp, các chi tiết hao mòn không đang kể.\r\n♻️ 4 Lốp còn đẹp, đủ 2 chìa zin, phụ kiện theo xe còn đầy đủ.\r\n\r\n✳️ Trang bị nổi bật của xe:\r\n🔅 Màn hình cảm ứng + đàm thoại rảnh tay.\r\n🔅 Ghế chỉnh điện - Cửa Sổ Trời - Đề nổ Star Stop - Cảm biến áp suất lốp.\r\n🔅 Điều hòa Auto - Đèn Auto - Ga Tự Động.\r\n🔅 Có sẵn thảm sàn - Film cách nhiệt - Bọc Trần 5D.\r\n🔅 Đăng kiểm mới đến 04/ 2026.\r\n\r\nCam kết của Chợ Tốt Xe Official Mall:\r\n✅Pháp Lý Đảm Bảo, Không đâm đụng, Không ngập nước, Không cháy nổ.\r\n✅Hỗ trợ cho vay trả góp lên đến 70%\r\n✅Đội ngũ nhân viên chuyên nghiệp nhiệt tình và chu đáo.\r\n✅Cam kết chất lượng theo tiêu chuẩn 207 điểm kiểm định của Chợ Tốt Xe.\r\n✅Lái thử xe ngay, không cần đặt cọc.\r\n✅Bao kiểm tra tại các xưởng và hãng trên toàn quốc.",
                Picture = "Assets/images/KiaCerato20181.6AT",
                Avatar = "..\\..\\Assets\\images\\KiaCerato20181.6AT\\1.jpg"
            },

            new()
            {
                CarId = 2,
                Name = "VinFast Fadil 1.4AT 2022",
                Manufacturer = "VinFast",
                EngineType = "Xăng",
                TypeOfCar = "Hatchback",
                Price = 325000000,
                UsageStatus = "Xe mới",
                Description = "",
                Picture = "Assets/images/VinFastFadil1.4AT2022",
                Avatar = "..\\..\\Assets\\images\\VinFastFadil1.4AT2022\\1.jpg"
            },

            new()
            {
                CarId = 3,
                Name = "Xpander AT Eco 2023",
                Manufacturer = "Mitsubishi",
                EngineType = "Xăng",
                TypeOfCar = "SUV",
                Price = 565000000,
                UsageStatus = "Xe cũ",
                Description = "",
                Picture = "Assets/images/XpanderATEco2023",
                Avatar = "..\\..\\Assets\\images\\XpanderATEco2023\\1.jpg"
            },

            new()
            {
                CarId = 4,
                Name = "Vinfast Lux SA2.0 2021",
                Manufacturer = "VinFast",
                EngineType = "Xăng",
                TypeOfCar = "Hatchback",
                Price = 828000000,
                UsageStatus = "xe Cũ",
                Description = "",
                Picture = "Assets/images/VinfastLuxSA2.02021",
                Avatar = "..\\..\\Assets\\images\\VinfastLuxSA2.02021\\1.jpg"
            },
        };

        return result;
    }

    public async Task<string> GetImagePath(StorageFolder folder, string imageName)
    {
        try
        {
            var files = await folder.GetFilesAsync();
            var file = files.FirstOrDefault(
                file => file.Name.StartsWith(imageName, StringComparison.OrdinalIgnoreCase));

            if (file != null)
                return file.Path;
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return "";
        }

    }
}
