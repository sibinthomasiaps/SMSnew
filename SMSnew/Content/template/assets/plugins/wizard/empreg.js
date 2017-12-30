

var form = $(".validatione-wizard").show();

$(".validatione-wizard").steps({
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
        //swal("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");
        var RollNumber = $('#EmpRollNumber').val();
        var Designation = $('#EmpDesignation').val();
        var fname = $('#EmpFirstName').val();
        var lname = $('#EmpLastName').val();

        var address1 = $('#EmpAddress1').val();
        var address2 = $('#EmpAddress2').val();
        var city = $('#EmpCity').val();
        var postcode = $('#EmpPINcode').val();

        var state = $('#EmpState').val();
        var country = $('#EmpCountry').val();
        var contactno = $('#EmpPhone').val();
        var gender = $('#EmpGender').val();

        var dob = $('#mdate1').val();
        var Department = $('#EmpDepartment').val();
        var email = $('#EmpEmail').val();
        var joindate = $('#mdate2').val();

        var experience = $('#EmpExperienced').val();
        var expdescription = $('#EmpExpDescription').val();
        var Photo = $('#EmpPhoto').val();
        var bloodgroup = $('#EmpBloodGroup').val();

        var username = $('#username').val();
        var passsword = $('#passsword').val();
        var Status = $('#EmpStatus').val();


        //alert($('#EmpBloodGroup').val());
        //  window.location = "TeacherInsert?address1=" + address1 + "&address2" + addrss2 + "&city" + city + "&state" + state + "&postcode" + postcode + "&country" + country + "&experience" + experience + "&qualification" + qualification + "&expdescription" + expdescription;
        window.location = "/Employee/EmployeeRegistration?lname=" + lname + "&Status=" + Status + "&Department=" + Department + "&Photo=" + Photo + "&fname=" + fname + "&RollNumber=" + RollNumber + "&gender=" + gender + "&bloodgroup=" + bloodgroup + "&dob=" + dob + "&joindate=" + joindate + "&contactno=" + contactno + "&Designation=" + Designation + "&email=" + email + "&address1=" + address1 + "&address2=" + address2 + "&city=" + city + "&state=" + state + "&postcode=" + postcode + "&country=" + country + "&experience=" + experience + "&expdescription=" + expdescription;
        // window.location = "EmployeeRegistration?fname=" + fname;

    }
}), $(".validatione-wizard").validate({
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