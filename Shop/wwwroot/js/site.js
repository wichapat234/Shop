﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Edit_Unit(id) {
    document.location = 'Edit_Unit_Page/?id=' + id;
}
function Edit_product(id) {
    document.location = 'Edit_Product_Page/?id=' + id;
}
function Add_Bill() {
    document.location = 'Home/Add_Bill';
}
function Detail_Bill(id) {
    document.location = 'Home/Detail_Bill/?id=' + id;
}
function BlackToList() {
    window.location.assign("https://localhost:44359/");
}
function Add_Unit() {
    document.location = 'Add_Unit_Page';
}
function Add_produuct() {
    document.location = 'Add_Product_Page';
}
function Save() {
    var name = document.getElementById('add_unit').value;
    console.log(name)
    if (name.trim() == "") {
        $('#validate_add_unit').text('กรอกข้อความ')
        $('#add_unit').css("border", "1px solid red");
        console.log("ไม่ผ่าน")
    } else {
        name = name.trim();
        console.log("ผ่าน")
        var obj = { Name: name }
        axios({
            method: 'post',
            url: '/Home/Insert_Unit',
            data: obj
        })
            .then(function (response) {
                console.log(response);
                if (response.data == 1) {
                    window.location = '/Home/List_Unit';
                }
                else {
                    alert("หน่วยสินค้าซ้ำ")
                }
            })
            .catch(function (error) {
                console.log(error);
            });
    }

}
function Save_Product() {
    var ProductName = document.getElementById('add_product').value;
    var ProductPrice = document.getElementById('add_price').value;
    var IdNoun = document.getElementById('add_unit').value;
    console.log(ProductName)
    console.log(ProductPrice)
    console.log(IdNoun)
    var idunit = parseInt(IdNoun)
    var price = parseFloat(ProductPrice)
    if (name.trim() =="" && ProductPrice.trim() == "") {
        $('#validate_add_unit').text('กรอกข้อความ')
        $('#add_unit').css("border", "1px solid red");
    } else {
        var obj = { ProductPrice: price, ProductName: ProductName, IdNoun: idunit }
        console.log(obj)
        axios({
            method: 'post',
            url: '/Home/Insert_Product',
            data: obj
        })
            .then(function (response) {
                console.log(response);
                window.location = '/Home/List_Product';
            })
            .catch(function (error) {
                console.log(error);
            });
    }

}
function Update(id) {
    var name = document.getElementById('unitEdit').value;
    console.log(name)
    if (name.trim() == "") {
        $('#validate_edit_unit').text('กรอกข้อความ')
        $('#unitEdit').css("border", "1px solid red");
    } else {
       var obj = { IdNoun: id, Name: name }
        axios({
            method: 'post',
            url: '/Home/Update',
            data: obj
        })
            .then(function (response) {
                console.log(response);
                if (response.data == 1) {
                    window.location = '/Home/List_Unit';
                }
                else {
                    alert("หน่วยสินค้าซ้ำ")
                }
            })
            .catch(function (error) {
                console.log(error);
            });
    }

}
function Update_Product(id) {
    var name_product = document.getElementById('edit_product').value;
    var price = document.getElementById('edit_price').value;
    var unit = document.getElementById('edit_unit').value;
    var idpro = parseInt(id)
    var price = parseFloat(price)
    var unit = parseInt(unit)
    if (name_product.trim()== "" && price.trim() == "") {
        $('#validate_edit_nameproduct').text('กรอกข้อความ')
        $('#edit_product').css("border", "1px solid red");
        $('#validate_edit_price').text('กรอกข้อความ')
        $('#edit_price').css("border", "1px solid red");
    } else {
        var obj = { IdProduct: idpro, ProductName: name_product, ProductPrice: price, IdNoun: unit }
        axios({
            method: 'post',
            url: '/Home/Update_Product',
            data: obj
        })
            .then(function (response) {
                console.log(response);
                window.location = '/Home/List_Product';
            })
            .catch(function (error) {
                console.log(error);
            });
    }

}
function Delete_Unit(id) {
    var obj = { IdNoun: id }
    axios({
        method: 'post',
        url: '/Home/Delete',
        data: obj
    })
        .then(function (response) {
            console.log(response);
            window.location.reload();
        })
        .catch(function (error) {
            console.log(error);
        });


}
function Delete_product(id) {
    var obj = { IdProduct: id }
    axios({
        method: 'post',
        url: '/Home/Delete_Product',
        data: obj
    })
        .then(function (response) {
            console.log(response);
            window.location.reload();
        })
        .catch(function (error) {
            console.log(error);
        });


}
