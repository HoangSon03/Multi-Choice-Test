const virtual_keyboard = document.querySelector('#may_tinh');
let id_inp = "";
$('input').click(function () {
    id_inp = $(this).attr('id');
    virtual_keyboard.style.display = 'block';
    console.log(id_inp);
});

function Lay_ket_qua() {
    return document.getElementById(id_inp).value;
}

function In_Ket_qua(so) {
    document.getElementById(id_inp).value = so;
}

var he_thong = document.getElementsByClassName('he_thong');
for (var i = 0; i < he_thong.length; i++) {
    he_thong[i].addEventListener('click', function () {
        if (this.id == "xoa_tat_ca") {
            In_Ket_qua("");
        }
        else if (this.id == "xoa_tung_so") {
            let ket_qua = Lay_ket_qua().toString();
            if (ket_qua) {
                ket_qua = ket_qua.substr(0, ket_qua.length - 1)
                In_Ket_qua(ket_qua)
            }
        }
        else {
            virtual_keyboard.style.display = 'none';
        }
    })
}

var con_so = document.getElementsByClassName('con_so');
for (var i = 0; i < con_so.length; i++) {
    con_so[i].addEventListener('click', function () {
        var ket_qua = Lay_ket_qua();
        if (ket_qua != NaN) {
            ket_qua = ket_qua + this.id;
            console.log(ket_qua)
            In_Ket_qua(ket_qua)
        }
    })
}
