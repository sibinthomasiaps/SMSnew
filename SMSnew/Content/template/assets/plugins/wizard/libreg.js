//$(".tab-wizard").steps({
//    headerTag: "h6"
//    , bodyTag: "section"
//    , transitionEffect: "fade"
//    , titleTemplate: '<span class="step">#index#</span> #title#'
//    , labels: {
//        finish: "Submit"
//    }
//    , onFinished: function (event, currentIndex) {
//       swal("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");
            
//    }
//});


var form = $(".validationl-wizard").show();

$(".validationl-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    , onStepChanging: function (event, currentIndex, newIndex) {
        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    }
    , onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    }
    , onFinished: function (onclick, currentIndex) {

        var Librarian = $('#Librarian').val();
        var SBN = $('#LibraryISBN').val();
        var Catagory = $('#LibraryBookCatagory').val();
        var Title = $('#LibraryBookTitle').val();

        var Edition = $('#LibraryBookEdition').val();
        var Publisher = $('#LibraryBookPublisher').val();
        var BookNo = $('#LibraryBookNo').val();
        var ShelfNo = $('#LibraryBookShelfNo').val();

        var Condition = $('#LibraryBookCondition').val();
        var BookCost = $('#LibraryBookCost').val();
        var Author = $('#LibraryBookAuthor').val();
        var NoCopies = $('#LibraryBookNoCopies').val();

        var Language = $('#LibraryBookLanguage').val();
        var BookStatus = $('#LibraryBookStatus').val();

        window.location = " /libarybookissue/libraryBookDataRegistration?Librarian=" + Librarian + "&SBN=" + SBN + "&Catagory=" + Catagory + "&Title=" + Title + "&Edition=" + Edition + "&Publisher=" + Publisher + "&BookNo=" + BookNo + "&ShelfNo=" + ShelfNo + "&Condition=" + Condition + "&BookCost=" + BookCost + "&Author=" + Author + "&NoCopies=" + NoCopies + "&Language=" + Language + "&BookStatus=" + BookStatus;

         //swal("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");

    }
}), $(".validationl-wizard").validate({
    ignore: "input[type=hidden]"
    , errorClass: "text-danger"
    , successClass: "text-success"
    , highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , errorPlacement: function (error, element) {
        error.insertAfter(element)
    }
    , rules: {
        email: {
            email: !0
        }
    }
})