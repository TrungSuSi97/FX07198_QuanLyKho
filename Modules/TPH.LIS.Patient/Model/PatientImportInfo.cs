using System;
using System.ComponentModel;

namespace TPH.LIS.Patient.Model
{
    public class ChiDinhXetNghiemKSK
    {
        public string MaDichVu { get; set; }
        public bool IsProfile { get; set; }
        public string MaLoaiDichVu { get; set; }
    }
    public class PatientImportInfo
    {
        [Description("Chung: Mã xét nghiệm")]
        public string Maxetnghiem { get; set; }
        [Description("Chung: Mã tiếp nhận")]
        public string Matiepnhan { get; set; }
        [Description("Chung: Barcode (LIS)")]
        public string Seq { get; set; }
        [Description("Chung: Nội trú")]
        public string Noitru { get; set; }
        [Description("Chung: Mã bệnh nhân")]
        public string Mabn { get; set; }
        [Description("Chung: Số BHYT")]
        public string Sobhyt { get; set; }
        [Description("Chung: Ngày hết hạn BHYT")]
        public string Ngayhethanbhyt { get; set; }
        [Description("Chung: Tên bệnh nhân")]
        public string Tenbn { get; set; }
        [Description("Chung: Sinh nhật")]
        public string Sinhnhat { get; set; }
        [Description("Chung: Năm sinh")]
        public string Tuoi { get; set; }
        [Description("Chung: Giới tính")]
        public string Gioitinh { get; set; }
        [Description("Chung: Ngày tiếp nhận")]
        public DateTime Ngaytiepnhan { get; set; }
        [Description("Chung: User nhập")]
        public string Usernhap { get; set; }
        [Description("Chung: Mã đối tượng")]
        public string Doituongdichvu { get; set; }
        [Description("Chung: Địa chỉ")]
        public string Diachi { get; set; }
        [Description("Chung: Số nhà")]
        public string Sonha { get; set; }
        [Description("Chung: Phường/xã")]
        public string Phuongxa { get; set; }
        [Description("Chung: Quận/Huyện")]
        public string Mahuyen { get; set; }
        [Description("Chung: Tỉnh/TP")]
        public string Matinh { get; set; }
        [Description("Chung: Email")]
        public string Email { get; set; }
        [Description("Chung: SDT")]
        public string Sdt { get; set; }
        [Description("Chung: Ngày vào viện")]
        public string Tgvaovien { get; set; }
        [Description("Chung: Mã khoa phòng")]
        public string Madonvi { get; set; }
        [Description("Chung: Tên khoa phòng/Đơn vị gửi mẫu")]
        public string Tendonvi { get; set; }
        [Description("Chung: BS Chỉ định")]
        public string Bacsicd { get; set; }
        [Description("Chung:Tên BS Chỉ định")]
        public string Tenbacsicd { get; set; }
        [Description("Chung: Chẩn đoán")]
        public string Chandoan { get; set; }
        [Description("Chung: Số phiếu chỉ định HIS")]
        public string Sophieuyeucau { get; set; }
        [Description("Chung: Ngày chỉ định HIS")]
        public string Ngaydk { get; set; }
        [Description("Chung: Số hồ sơ")]
        public string Bn_id { get; set; }
        [Description("Chung: Mã nơi cấp BHYT")]
        public string Manoicapthebhyt { get; set; }
        [Description("Chung: Mã nơi đặng ký BHYT")]
        public string Manoidangkythebhyt { get; set; }
        [Description("Chung: Giường")]
        public string Giuong { get; set; }
        [Description("Chung: Buồng")]
        public string Buong { get; set; }
        [Description("Chung: ID Công dân")]
        public string Idcongdan { get; set; }
        [Description("Chung: Đối tượng theo dõi")]
        public string Doituong { get; set; }
        [Description("Chung: Nhóm máu")]
        public string Abo { get; set; }
        [Description("Chung: Rh")]
        public string Rh { get; set; }
        [Description("Chung: Ngày nhập viện")]
        public string Ngaynhapvien { get; set; }
        [Description("Chung: Số hộ chiếu")]
        public string Sohochieu { get; set; }
        [Description("Chung: Ngày cấp hộ chiếu")]
        public string Ngaycaphochieu { get; set; }
        [Description("Chung: Ghi chú hộ chiếu")]
        public string Ghichuhochieu { get; set; }
        [Description("Chung: Quốc tịch")]
        public string Quoctich { get; set; }
        //thông tin sàng lọc
        [Description("Sàng lọc: Barcode lấy mẫu")]
        public string Barcodelaymau { get; set; }
        [Description("Sàng lọc SS: Tuổi thai")]
        public string Tuoithai { get; set; }
        [Description("Sàng lọc SS: Nơi sinh")]
        public string Noisinh { get; set; }
        [Description("Sàng lọc SS: Cân nặng")]
        public string Cannang { get; set; }
        [Description("Sàng lọc SS: Chiều cao")]
        public string Chieucao { get; set; }
        [Description("Sàng lọc SS: Ngày sinh")]
        public string Ngaysinh { get; set; }
        [Description("Sàng lọc SS: Giờ sinh")]
        public string Giosinh { get; set; }
        [Description("Sàng lọc SS: Dân tộc")]
        public string Dantoc { get; set; }
        [Description("Sàng lọc SS: Số lượng sinh")]
        public string Soluongsinh { get; set; }
        [Description("Sàng lọc SS: Tình trạng bình thường")]
        public string Ttbinhthuong { get; set; }
        [Description("Sàng lọc SS: Tình trạng đang bệnh")]
        public string Ttdangbenh { get; set; }
        [Description("Sàng lọc SS: Tình trạng dùng kháng sinh")]
        public string Ttdungkhangsinh { get; set; }
        [Description("Sàng lọc SS: Tình trạng dùng Steriod")]
        public string Ttdungsteriod { get; set; }
        [Description("Sàng lọc SS: Tình trạng truyền máu")]
        public string Tttruyenmau { get; set; }
        [Description("Sàng lọc SS: Tình trạng lượng truyển máu")]
        public string Ttluongtruyenmau { get; set; }
        [Description("Sàng lọc SS: Lấy mẫu gót chân")]
        public string Vitrigotchan { get; set; }
        [Description("Sàng lọc SS: Lấy mẫu tĩnh mạch")]
        public string Vitritinhmach { get; set; }
        [Description("Sàng lọc SS: Lấy mẫu vt khác")]
        public string Vitrikhac { get; set; }
        [Description("Sàng lọc SS: Bú mẹ")]
        public bool Dinhduongbume { get; set; }
        [Description("Sàng lọc SS: Bú bình")]
        public string Dinhduongbubinh { get; set; }
        [Description("Sàng lọc SS: DD Tĩnh mạch")]
        public bool Dinhduongtinhmach { get; set; }
        [Description("Sàng lọc SS: Đẻ thường")]
        public string Kieudethuong { get; set; }
        [Description("Sàng lọc SS: Đẻ mổ")]
        public string Kieudemo { get; set; }
        [Description("Sàng lọc SS: Đẻ kiểu khác")]
        public string Kieudekhac { get; set; }
        [Description("Sàng lọc: Họ tên/Họ tên đệm mẹ")]
        public string Hotenme { get; set; }
        [Description("Sàng lọc: Tên mẹ")]
        public string Tenme { get; set; }
        [Description("Sàng lọc: Họ tên bố")]
        public string Hotenbo { get; set; }
        [Description("Sàng lọc: Năm sinh mẹ")]
        public int Namsinhme { get; set; }
        [Description("Sàng lọc: Năm sinh bố")]
        public string Namsinhbo { get; set; }
        [Description("Sàng lọc: Điện thoại bàn")]
        public string Dienthoaiban { get; set; }
        [Description("Sàng lọc: Điện thoại di động")]
        public string Dienthoaididong { get; set; }
        [Description("Sàng lọc: Para1")]
        public string Para1 { get; set; }
        [Description("Sàng lọc: Para2")]
        public string Para2 { get; set; }
        [Description("Sàng lọc: Para3")]
        public string Para3 { get; set; }
        [Description("Sàng lọc: Para4")]
        public string Para4 { get; set; }
        [Description("Sàng lọc: Para5")]
        public string Para5 { get; set; }
        [Description("Sàng lọc: Ngày lấy mẫu")]
        public string Ngaylaymau { get; set; }
        [Description("Sàng lọc: Giờ lấy mẫu")]
        public string Giolaymau { get; set; }
        [Description("Sàng lọc: Thời gian lấy mẫu")]
        public string Thoigianlaymau { get; set; }
        [Description("Sàng lọc: Ngày dự sinh")]
        public string Ngaydusinh { get; set; }
        [Description("Sàng lọc: Ngày nhận mẫu")]
        public string Ngaynhanmau { get; set; }
        [Description("Sàng lọc: Giờ nhận mẫu")]
        public string Gionhanmau { get; set; }
        [Description("Sàng lọc: Thời gian nhận mẫu")]
        public string Thoigiannhanmau { get; set; }

        [Description("Sàng lọc: Người lấy mẫu")]
        public string Tennguoilaymau { get; set; }
        [Description("Sàng lọc: Người nhận mẫu")]
        public string Tennguoinhanmau { get; set; }

        [Description("Sàng lọc: Mã người lấy mẫu")]
        public string Manguoilaymau { get; set; }
        [Description("Sàng lọc: Mã người nhận mẫu")]
        public string Manguoinhanmau { get; set; }

        [Description("Sàng lọc: Nơi gửi")]
        public string Noiguimau { get; set; }
        [Description("Sàng lọc: Địa chỉ nơi gửi mẫu")]
        public string Diachinoiguimau { get; set; }
        [Description("Sàng lọc: Mã tỉnh gửi mẫu")]
        public string Matinhguimau { get; set; }
        [Description("Sàng lọc: Mã huyện gửi mẫu")]
        public string Mahuyenguimau { get; set; }
        [Description("Sàng lọc: Nhận xét sàng lọc")]
        public string Nhanxetsangloc { get; set; }
        [Description("Sàng lọc: Đề nghị sàng lọc")]
        public string Denghisangloc { get; set; }
        [Description("Sàng lọc: Người nhận xét")]
        public string Nguoinhanxet { get; set; }
        [Description("Sàng lọc: Người đề nghị")]
        public string Nguoidenghi { get; set; }
        [Description("Sàng lọc: Kết luận sàng lọc")]
        public string Ketluansangloc { get; set; }
        [Description("Sàng lọc: Người kết luận")]
        public string Nguoiketluan { get; set; }
        [Description("Sàng lọc: Người ký tên")]
        public string Nguoikyten { get; set; }
        [Description("Sàng lọc: Cân nặng mẹ")]
        public string Cannangme { get; set; }
        [Description("Sàng lọc: Chiều cao mẹ")]
        public string Chieucaome { get; set; }
        [Description("Sàng lọc: Số thai")]
        public string Sothai { get; set; }
        [Description("Sàng lọc: Tuổi thai (mẹ)")]
        public string Tuoithaime { get; set; }
        [Description("Sàng lọc: IVF")]
        public string Ivf { get; set; }
        [Description("Sàng lọc: Hút thuốc")]
        public string Hutthuoc { get; set; }
        [Description("Sàng lọc: BPD")]
        public string Bpd { get; set; }
        [Description("Sàng lọc: Chủng tộc")]
        public string Chungtoc { get; set; }
        [Description("Sàng lọc: Đái tháo đường (1)")]
        public string Daithaoduong { get; set; }
        [Description("Sàng lọc: Tiền sử")]
        public string Tiensu { get; set; }
        [Description("Sàng lọc: BS Siêu âm")]
        public string Bssieuam { get; set; }
        [Description("Sàng lọc: Ngày siêu âm")]
        public string Ngaysieuam { get; set; }
        [Description("Sàng lọc: BMI")]
        public string Bmi { get; set; }
        [Description("Sàng lọc: CRL")]
        public string Crl { get; set; }
        [Description("Sàng lọc: Xương mũi")]
        public string Xuongmui { get; set; }
        [Description("Sàng lọc: Dai thao đường(2)")]
        public string Daithaoduong2 { get; set; }
        [Description("Sàng lọc: Tang HS mãn tính")]
        public string Tanghamantinh { get; set; }
        [Description("Sàng lọc: Thai phụ TSG")]
        public string Thaiphumactsg { get; set; }
        [Description("Sàng lọc: Mẹ thai phụ TSG")]
        public string Methaiphumactsg { get; set; }
        [Description("Sàng lọc: H. C. AntiphosphoLipid")]
        public string Antiphospholipid { get; set; }
        [Description("Sàng lọc: Lupus ban đỏ")]
        public string Lupusbando { get; set; }
        [Description("Sàng lọc: Đã có thai > 24T")]
        public string Dacothaihon24 { get; set; }
        [Description("Sàng lọc: Ngày sinh lần trước")]
        public string Ngaysinhtruoc { get; set; }
        [Description("Sàng lọc: Tuổi thai lần sinh trước")]
        public string Tuoithaisinhtruoc { get; set; }
        [Description("Sàng lọc: Sinh con T24-T18-T13")]
        public string Sinhcont21t18t13 { get; set; }
        [Description("Sàng lọc: Người xác nhận KQ")]
        public string NguoixacnhanKQ { get; set; }
        [Description("Chung: ID Profile")]
        public string ProfileID { get; set; }
    }
}
