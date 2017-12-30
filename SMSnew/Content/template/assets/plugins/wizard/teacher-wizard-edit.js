var form = $(".validationtedit-wizard").show();

$(".validationtedit-wizard").steps({
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
        var id = $('#TeacherID').val();
        var fname = $('#TeacherFirstName').val();
        var lname = $('#TeacherLastName').val();
        var gender = $('input:radio[name="Gender"]:checked').val();
        var bloodgroup = $('#TeacherBloodGroup').val();
        var dob = $('#mdate1').val();
        var joindate = $('#mdate2').val();
        var contactno = $('#TeacherContactNumber').val();
        var email = $('#TeacherEmail').val();
        var address1 = $('#TeacherAddress1').val();
        var address2 = $('#TeacherAddress2').val();
        var city = $('#TeacherCity').val();
        var state = $('#TeacherState').val();
        var country = $('#TeacherCountry').val();
        var postcode = $('#TeacherPINcode').val();
        var experience = $('#TeacherExperienced').val();
        var qualification = $('#TeacherQualification').val();
        var expdescription = $('#TeacherExpDescription').val();
        var modidescription = $('#TeacherModifiedDescription').val();
        window.location = "/Teacher/TeacherEdit1?id=" + id + "&lname=" + lname + "&fname=" + fname + "&gender=" + gender + "&bloodgroup=" + bloodgroup + "&dob=" + dob + "&joindate=" + joindate + "&contactno=" + contactno + "&email=" + email + "&address1=" + address1 + "&address2=" + address2 + "&city=" + city + "&state=" + state + "&postcode=" + postcode + "&country=" + country + "&experience=" + experience + "&qualification=" + qualification + "&expdescription=" + expdescription + "&description=" + modidescription;
    }
}),


$(".validationtedit-wizard").validate({
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
});

