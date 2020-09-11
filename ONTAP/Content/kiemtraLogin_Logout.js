
function XuLyDangNhap() {
    var tenDN = document.getElementById("txtTenTK").value.trim();
    var matKhau = document.getElementById("txtMatKhau").value.trim();
    if (tenDN == null || tenDN == "") {
        alert("Tài khoản không được để trống");
        document.getElementById("txtTenTK").focus();
        return false;
    }
    if (matKhau == null || matKhau == "" ) {
        alert("Mật khẩu không được để trống");
        document.getElementById("txtMatKhau").focus();
        return false;
    }
    if (tenDN.length < 5 || tenDN.length > 20) {
        alert("Độ dài tài khoản phải nằm trong khoảng 5 đến 20 ký tự");
        document.getElementById("txtTenTK").focus();
        return false;
    }
    if (matKhau.length < 4 || matKhau.length > 8) {
        alert("Độ dài mật khẩu phải nằm trong khoảng 4 đến 8 ký tự");
        document.getElementById("txtMatKhau").focus();
        return false;
    }

    //if (hasWhiteSpace(tenDN)) {
    //    alert("Tài khoản không được chứa khoảng trắng");
    //    document.getElementById("txtTenTK").focus();
    //    return false;
    //}
    //if (hasWhiteSpace(matKhau)) {
    //    alert("Mật khẩu không được chứa khoảng trắng");
    //    document.getElementById("txtMatKhau").focus();
    //    return false;
    //}
    return true;

}

function hasWhiteSpace(strInput) {
    return /\s/g.test(strInput);
}

function Validate() {
    var matKhau = document.getElementById("txtMatKhau").value;
    var re_matKhau = document.getElementById("re_txtMatKhau").value;
    var hoTen = document.getElementById("txtHoTen").value;
    var tenTK = document.getElementById("txtTenTK").value;
    var ngaySinh = document.getElementById("txtNgaySinh").value;
    var sdt = document.getElementById("txtDienThoai").value;
    var diaChi = document.getElementById("txtDiaChi").value;
    var email = document.getElementById("txtEmail").value;

    //Phần kiểm tra input
    if (checkTextBox(tenTK) != "") {
        alert("Tên đăng nhập " + checkTextBox(tenTK));
        document.getElementById("txtTenTK").focus();
        return false;
    }

    if (checkTextBox(matKhau) != "") {
        alert("Mật khẩu " + checkTextBox(matKhau));
        document.getElementById("txtMatKhau").focus();
        return false;
    }

    if (hoTen == null || hoTen == "") {
        alert("Họ và tên không được để trống");
        document.getElementById("txtHoTen").focus();
        return false;
    }

    if (diaChi == null || diaChi == "") {
        alert("Địa chỉ không đươc để trống");
        document.getElementById("txtDiaChi").focus();
        return false;
    }

    if (email == null || email == "") {
        alert("Email không đươc để trống");
        document.getElementById("txtEmail").focus();
        return false;
    }

    //Phần xử lý input
    if (/^[a-zA-Z0-9]*$/.test(tenTK) == false) {
        alert("Tên tài khoản không được chứa ký tự đặc biệt.");
        document.getElementById("txtTenTK").focus();
        return false;
    }

    var n = tenTK.length;
    if (n < 5 || n > 20) {
        alert("Tên tài khoản chỉ chứa từ 5 đến 20 ký tự.");
        document.getElementById("txtTenTK").focus();
        return false;
    }

    if (/^[a-zA-Z0-9]*$/.test(matKhau) == false) {
        alert("Mật khẩu không được chứa ký tự đặc biệt.");
        document.getElementById("txtMatKhau").focus();
        return false;
    }

    var m = matKhau.length;
    if (m < 4 || m > 8) {
        alert("Mật khẩu chỉ chứa từ 4 đến 8 ký tự");
        document.getElementById("txtMatKhau").focus();
        return false;
    }

    if (matKhau != re_matKhau) {
        alert("Mật khẩu nhập lại không trùng khớp");
        document.getElementById("re_txtMatKhau").focus();
        return false;
    }

    var phoneVN_regex = /((09|03|07|08|05)+([0-9]{8})\b)/g;
    //Viettel 09, 03; Mobi 09, 07; Vina 09, 08; VietnamMobile GMobli 09, 05
    if (phoneVN_regex.test(sdt) == false) {
        alert("Số điện thoại không đúng định dạng.");
        document.getElementById("txtDienThoai").focus();
        return false;
    }

    var name = hoTen.length;
    if (name > 100) {
        alert("Tên người dùng không được quá 100 kí tự");
        document.getElementById("txtHoTen").focus();
        return false;
    }

    if (ngaySinh == "") {
        alert("Ngày sinh không hợp lệ");
        document.getElementById("txtNgaySinh").focus();
        return false;
    }

    

    var address = diaChi.length;
    if (address > 100) {
        alert("Địa chỉ quá dài.");
        document.getElementById("txtDiaChi").focus();
        return false;
    }

    var emailLength = email.length;
    if (emailLength > 100) {
        alert("Email quá dài.");
        document.getElementById("txtEmail").focus();
        return false;
    }

    return true;
}

function checkTextBox(strInput) {
    if (strInput == null || strInput == "")
        return "không được để trống!!!";
    if (hasWhiteSpace(strInput))
        return "không được chứa khoảng trắng";
    return "";
}


function confirmLogout() {
    alert("Đăng xuất thành công");
}