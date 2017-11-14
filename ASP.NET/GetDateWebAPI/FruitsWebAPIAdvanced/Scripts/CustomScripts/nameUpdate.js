(function () {
    var baseUri = "/api/fruits";

    function loadList() {
        $.ajax({
            url: baseUri,

            success: function (fruits) {

                var list = $("#names");
                list.empty();

                for (var i = 0; i < fruits.length; i++) {
                    var name = fruits[i];
                    list.append("<li>" + name + "</li>");
                }
            }
        });
    }

    loadList();

    $(document).ready(function () {
        $("#addNewBtn").on("click", postFruit);
        $("#changeBtn").on("click", putFruit);
        $("deleteBtn").on("click", deleteFruit);
    });

    function postFruit() {

        var nameToPost = $("#newName").val(); //Получаем имя нового элемента

        $.ajax({
            url: baseUri,
            type: "POST",
            data: JSON.stringify(nameToPost), //Сериализуем данные в JSON объект
            dataType: "json", //Подсказываем серверу, что хотим получить JSON
            contentType: "application/json", //...чтобы сервер понимал 
            //какие данные от клиента поступают

            statusCode: { //Определяем что произойдет, если с сервера придут разные статус коды
                201: function () {
                    alert("Created. Name added successfully");
                },
                400: function () {
                    alert("Bad Request. Operation not executed");
                }
            },

            //Если сервер вернет статус код 200
            success: function (data, textStatus, xhr) {
                //data - информация переданная обратно в теле ответа
                //textStatus - статус операции
                //xhr - объект XMLHttpRequest

                //Т.к. мы успешно создали файл, то мы указали Location, следовательно можем его получить
                var locationHeader = xhr.getResponseHeader("Location"); //при помощи getResponceHeader и указании его имени

                $("#location").html("<a href='" + locationHeader + "'>последний элемент</a>");

                $("#names").append("<li>" + data + "</li>");
            },

            error: errorHandler
        });
    };

    function putFruit() {

    };

    function deleteFruit() {

    };

    function errorHandler(xhr, textStatus, error) {
        if (xhr.status == "404") {
            alert('Element not found')
        }
        else if (xhr.status == "400") {
            alert('Server error')
        }
        else if (xhr.status == "500") {
            alert('Request generated incorrectly')
        }
    }

})();