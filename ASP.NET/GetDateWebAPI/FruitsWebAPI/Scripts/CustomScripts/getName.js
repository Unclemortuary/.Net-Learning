(function () {
    // Функция вызывается при загрузке скрипта и делает асинхронный запрос на сервер

    var baseUri = "/api/fruits";
    function loadList()
    {
        $.ajax({

            url: baseUri,

            success: function (names) { //Если сервер вернет статус код 200
                //То по умолчанию мы получим набор (names) обычных строк в формате JSON
                var list = $("#names"); //находим элемент на странице (<ul id="names")

                for (var i = 0; i < names.length; i++) {
                    var name = names[i];
                    list.append("<li>" + name + "</li>"); //Сразу же при загрузке страницы мы сформируем ul из данных, взятых с сервера!
                }
            }
        });
    }

    loadList();
    /*
    $(document).ready(function ()) {
        $("#button").on("click", getName);
    });

    function getName() {
        //uri в формате /api/names/5
        var link = "/api/fruits/" + $("#elementId").val();

        $.ajax({
            url: link,
            type: "GET",

            success: function (data) {
                $("#receivedElement").text(data); //вывод результата
            },

            error: function (xhr) {
                if (xhr.status == "404") {
                    alert("Элемент по указанному индексу не найден");
                    $("#receivedElement").text(xhr.responceText);
                }
                if (xhr.status == "500") {
                    alert("Ошибка сервера")
                }
            }
        });
    }
    */
})();