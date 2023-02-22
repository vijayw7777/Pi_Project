
$(document).ready(function () {
    ShowData();
    $("#spinner").show();
});


function ShowData() {

    $.ajax({
        url: '/Product/ProductinfoList',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {

            console.log(JSON.stringify(result));


            var object = '';
            $("#spinner").hide();
            $.each(result, function (index, item) {
                object += '<div style="height: 100%; width: 100%;" > ';

                object += '<div class="accordion accordion-flush" id="accordionFlushExample" >';
                object += '<div class="accordion-item" >';

                object += '  <h2 class="accordion-header" id="flush-heading' + index + '">';
                object += '     <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse' + index + '" aria-expanded="false" aria-controls="flush-collapse' + index + '" style="border: 1px solid blue;color:black;"> ';
                object += '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID: ' + item.productId + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product Name:' + item.productName + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Order Count:' + item.countOfOrderPerProduct + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Customer Count:' + item.countOfCustomerPerProduct + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;Total Revenue:' + item.totalRevenuePerProduct;
                object += '    </button>';
                object += '  </h2>';

                object += ' <div id="flush-collapse' + index + '" class="accordion-collapse collapse" aria-labelledby="flush-heading' + index + '" data-bs-parent="#accordionFlushExample">';
                object += ' <div class="accordion-body">';


                object += '  <div class="d-flex justify-content-evenly" style="padding-top:10px;padding-bottom:10px">';
                object += '     <div class="float-child" style="padding-right:10px;padding-left:10px">';
                object += '         <img src='+item.image+' width="200" height="150">';
                object += '     </div>';
                object += '     <div class="float-child">';
                object += '         <h3>' + item.discription + '</h3>';
                object += '     </div>';
                object += '  </div>';


                object += '  <div class="d-flex justify-content-evenly" style="padding-top:10px;padding-bottom:10px">';
                object += '          <div class="box" onclick="showModal1(' + item.productId + ')" border-inline-color: red;writing - mode: horizontal - tb; style=" background-color:#CDCDCD;" >';
                object += '               <h1  style="margin-top:50px; margin-bottom: 20px; font-size: 70px;color:blue;">' + item.countOfOrderPerProduct + '</h1>';
                object += '               <p style="margin-top: 80px; margin-bottom: 10px; font-size: 20px;">Total Orders Count</p>';
                object += '           </div>';
                object += '           <div class="box" onclick="showModal1(' + item.productId + ')" style="background-color: #CDCDCD;">';
                object += '                <h1 style="margin-top: 50px; margin-bottom: 20px; font-size: 70px; color:white;">' + item.totalRevenuePerProduct + '</h1>';
                object += '                <p style="margin-top: 80px; margin-bottom: 10px;font-size: 20px;">Total Revenue Generated </p>';
                object += '           </div>';
                object += '           <div class="box" onclick="showModal3(' + item.productId + ')" style="background-color: #CDCDCD;">';
                object += '               <h1 style="margin-top: 50px; margin-bottom: 20px; font-size: 70px;color: blue;">' + item.countOfCustomerPerProduct + '</h1>';
                object += '                <p style="margin-top: 80px; margin-bottom: 10px;font-size: 20px;">Total Customer Count </p>';
                object += '           </div> ';
                object += '  </div>';

                object += '</div > ';
                object += '</div > ';


                object += '</div>';
                object += '</div>';


                object += '</div > ';

            });

            $('#collaps').html(object);

        },
        beforeSend: function () {
            $("#spinner").show();
        },
        error: function () {

            alert("Data can't get..!!");
        }

    });
};

function ShowCusromerData(id) {

    //var product = $('#urlEmployeeData').val();
    $.ajax({
        url: '/product/CustomerList/?id=' + id,
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {
            console.log(JSON.stringify(result));
            setTimeout(function () {
                var object = '';
                $("#spinner3").hide();
                $.each(result, function (index, item) {
                    object += '<tr class="text-center">';
                    object += '<td>' + item.customerId + '</td>';
                    object += '<td>' + item.firstName + '</td>';
                    object += '<td>' + item.middleName + '</td>';
                    object += '<td>' + item.lastName + '</td>';
                    object += '<td>' + item.city + '</td>';
                    object += '<td>' + item.state + '</td>';
                    object += '</tr>';
                });
                $('#customer_data').html(object);
            }, 2000);

        },
        beforeSend: function () {
            $("#spinner3").show();
        },
        error: function () {
            alert("Data can't get..!!");
        }

    });
};


function ShowOrderData(id) {

    //var product = $('#urlEmployeeData').val();
    $.ajax({
        url: '/product/OrderList/?id=' + id,
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {
            setTimeout(function () {
                $("#spinner1").hide();
                console.log(JSON.stringify(result));
                var object = '';
                $.each(result, function (index, item) {
                    object += '<tr class="text-center">';
                    object += '<td>' + item.orderId + '</td>';
                    object += '<td>' + item.customerId + '</td>';
                    object += '<td>' + item.orderDate.substring(0, 10) + '</td>';
                    object += '</tr>';
                });
                $('#order_data').html(object);
            }, 2000);

        },
        beforeSend: function () {
            $("#spinner1").show();
        },


        error: function () {
            alert("Data can't get..!!");
        }

    });
};




function showModal1(productid) {
    ShowOrderData(productid);
    var modal = document.querySelector("#modal1")
    modal.style.display = "block";
}

function closeModal1() {
    var modal = document.querySelector("#modal1");
    modal.style.display = "none";
}


function showModal2(productid) {

    ShowOrderData(productid);
    var modal = document.querySelector("#modal2");
    modal.style.display = "block";
}

function closeModal2() {
    var modal = document.querySelector("#modal2");
    modal.style.display = "none";
}


function showModal3(productid) {
    ShowCusromerData(productid)

    var modal = document.querySelector("#modal3");
    modal.style.display = "block";
}

function closeModal3() {
    var modal = document.querySelector("#modal3");
    modal.style.display = "none";
}

function ShowFilterProductData() {

    var objData = $('#src').val();
    var obj = {
        name: objData
    }
    $.ajax({

        url: '/Product/SearchByProductName',
        type: 'get',
        dataType: 'json',
        data: obj,
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {

            console.log(JSON.stringify(result));
            var object = '';
            $("#spinner").hide();
            $.each(result, function (index, item) {
                object += '<div style="height: 100%; width: 100%;" > ';

                object += '<div class="accordion accordion-flush" id="accordionFlushExample" >';
                object += '<div class="accordion-item" >';

                object += '  <h2 class="accordion-header" id="flush-heading' + index + '">';
                object += '     <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse' + index + '" aria-expanded="false" aria-controls="flush-collapse' + index + '" style="border: 1px solid blue;color:black;"> ';
                object += '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID: ' + item.productId + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product Name:' + item.productName + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Order Count:' + item.countOfOrderPerProduct + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Customer Count:' + item.countOfCustomerPerProduct + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;Total Revenue:' + item.totalRevenuePerProduct;
                object += '    </button>';
                object += '  </h2>';

                object += ' <div id="flush-collapse' + index + '" class="accordion-collapse collapse" aria-labelledby="flush-heading' + index + '" data-bs-parent="#accordionFlushExample">';
                object += ' <div class="accordion-body">';


                object += '  <div class="d-flex justify-content-evenly" style="padding-top:10px;padding-bottom:10px">';
                object += '     <div class="float-child" style="padding-right:10px;padding-left:10px">';
                object += '         <img src="https://i.pinimg.com/564x/59/32/29/593229739184504afd9507cc42a9cb86.jpg" width="200" height="150">';
                object += '     </div>';
                object += '     <div class="float-child">';
                object += '         <h3>' + item.discription + '</h3>';
                object += '     </div>';
                object += '  </div>';


                object += '  <div class="d-flex justify-content-evenly" style="padding-top:10px;padding-bottom:10px">';
                object += '          <div class="box" onclick="showModal1(' + item.productId + ')" border-inline-color: red;writing - mode: horizontal - tb; style=" background-color:#CDCDCD;" >';
                object += '               <h1  style="margin-top:50px; margin-bottom: 20px; font-size: 70px;color:blue;">' + item.countOfOrderPerProduct + '</h1>';
                object += '               <p style="margin-top: 80px; margin-bottom: 10px; font-size: 20px;">Total Orders Count</p>';
                object += '           </div>';
                object += '           <div class="box" onclick="showModal1(' + item.productId + ')" style="background-color: #CDCDCD;">';
                object += '                <h1 style="margin-top: 50px; margin-bottom: 20px; font-size: 70px; color:white;">' + item.totalRevenuePerProduct + '</h1>';
                object += '                <p style="margin-top: 80px; margin-bottom: 10px;font-size: 20px;">Total Revenue Generated </p>';
                object += '           </div>';
                object += '           <div class="box" onclick="showModal3(' + item.productId + ')" style="background-color: #CDCDCD;">';
                object += '               <h1 style="margin-top: 50px; margin-bottom: 20px; font-size: 70px;color: blue;">' + item.countOfCustomerPerProduct + '</h1>';
                object += '                <p style="margin-top: 80px; margin-bottom: 10px;font-size: 20px;">Total Customer Count </p>';
                object += '           </div> ';
                object += '  </div>';

                object += '</div > ';
                object += '</div > ';


                object += '</div>';
                object += '</div>';


                object += '</div > ';

            });

            $('#collaps').html(object);

        },
        beforeSend: function () {
            $("#spinner").show();
        },
         error: function () {
            alert("Data can't get..!!");
        }

    });
};








//beforeSend: function () {
//    $("#loader").show();
//},

//setTimeout(function () {

//}, 3000);