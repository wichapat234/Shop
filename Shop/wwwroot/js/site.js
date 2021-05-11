// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function Add_Bill() {
    window.location.href = 'Transaction/Add_Bill';
}
function Detail_Bill(id) {
    window.location.href = 'Transaction/Detail_Bill/?id=' + id;
}
function BlackToList() {
    window.location.href = "https://localhost:44359/";
}

function Add_Unit() {
    window.location.href = 'Add_Unit_Page'
   // document.location = 'Add_Unit_Page';
}
function Add_produuct() {
    window.location.href = 'Add_Product_Page';
}



