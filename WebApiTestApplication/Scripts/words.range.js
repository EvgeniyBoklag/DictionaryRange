(function ($) {
    var wordsData = {};
    var showMore = function (firstLetter, template) {
        var contentElement = $(template).find(".content");
        $(contentElement).empty();
        $(contentElement).append(wordsData[firstLetter]);
    }
    var processResult = function(wordsArray) {
        var firstLetter = "";
        var count = 0;
        var lastTemplate = "";
        wordsArray.forEach( function myFunction(item, index) {
            count++;
            if (item[0] !== firstLetter) {

                count = 0;
                firstLetter = item[0];
                wordsData[firstLetter] = "";
                var tmplHtml = $("#rangeTemplate").html();

                var el = $(tmplHtml);
                lastTemplate = el;

                var inner = $(el).find(".inner");
                $(inner).text(firstLetter);
                $("#wordsContainer").append(el);
                var link = $(el).find(".show-all");
                var letter = firstLetter;
                link.click(function () {
                    showMore(letter, el);
                    link.css("visibility", "hidden");
                });
                firstLetter = item[0];
            }

            if (count === 80) {

                var linkElement = $(lastTemplate).find(".show-all");
                linkElement.css("visibility", "visible");
                return true;
            }
            var wordItem = item + " ";
            if (count < 80) {
                var contentElement = $(lastTemplate).find(".content");
                $(contentElement).append(wordItem);
            }
            wordsData[firstLetter] += wordItem;
        });
    };


    if (!document.location.search) {
        return;
    }

    var params = $.parseParams(document.location.search.toLowerCase());
    
    if (!params.from || !params.to) {
        return;
    }

    $.ajax({
        method: "GET",
        url: "/api/Word",
        data: { from: params.from, to: params.to }
    })
  .done(function (wordsArray) {
      processResult(wordsArray);
      
  })
  .error(function (xhr, status, error) {
      BootstrapDialog.show({
          message: xhr.responseText,
          title: "Warning",
          buttons: [{
              label: 'Close',
              cssClass: 'btn-warning',
              action: function(dialogItself) {
                  $("#wordsContainer").empty();
                  dialogItself.close();

              }
          }]
      });
  })
    ;
})(jQuery);