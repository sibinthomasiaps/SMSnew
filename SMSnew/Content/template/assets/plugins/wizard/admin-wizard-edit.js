var form = $(".validationaedit-wizard").show();

$(".validationaedit-wizard").steps({
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


        var fname = $('#AdminFullname').val();
        var Department = $('#Department').val();
        var JoiningDate = $('#JoiningDate').val();
        var Address = $('#Address').val();
        var Address1 = $('#Address1').val();
        var City = $('#City').val();
        var State = $('#State').val();
        var PINcode = $('#PINcode').val();
        var Country = $('#Country').val();
        var ContactNumber = $('#ContactNumber').val();
        var TotalExperience = $('#TotalExperience').val();
        var Qualification = $('#Qualification').val();
        var ExperienceInfo = $('#ExperienceInfo').val();
        // var val = $("#Gender:checked").val();

        var val = $('input:radio[name="Gender"]:checked').val();



        window.location = "adminprofileedit1?fname=" + fname + "&Department=" + Department + "&JoiningDate=" + JoiningDate + "&Department=" + Department + "&Address=" + Address + "&Address1=" + Address1 + "&City=" + City + "&State=" + State + "&PINcode=" + PINcode + "&Country=" + Country + "&ContactNumber=" + ContactNumber + "&TotalExperience=" + TotalExperience + "&Qualification=" + Qualification + "&Department=" + Department + "&ExperienceInfo=" + ExperienceInfo + "&PINcode=" + PINcode + "&Gender=" + val;
        //"&TeacherLastName=" + wlastName2;



       
    }
}),


$(".validationaedit-wizard").validate({
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