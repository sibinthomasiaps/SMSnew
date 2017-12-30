﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMSnew.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SMSnewEntities : DbContext
    {
        public SMSnewEntities()
            : base("name=SMSnewEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Admission> Admissions { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceCard> AttendanceCards { get; set; }
        public virtual DbSet<AttendancePerson> AttendancePersons { get; set; }
        public virtual DbSet<Circular> Circulars { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<ComplaintBox> ComplaintBoxes { get; set; }
        public virtual DbSet<DebitCard> DebitCards { get; set; }
        public virtual DbSet<DebitCardRecharge> DebitCardRecharges { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamCategory> ExamCategories { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<ExamMark> ExamMarks { get; set; }
        public virtual DbSet<FeeCategory> FeeCategories { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<FeesPayment> FeesPayments { get; set; }
        public virtual DbSet<FeeTermReg> FeeTermRegs { get; set; }
        public virtual DbSet<Fine> Fines { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<HostelFee> HostelFees { get; set; }
        public virtual DbSet<HostelFeePayment> HostelFeePayments { get; set; }
        public virtual DbSet<HostelFeeStructure> HostelFeeStructures { get; set; }
        public virtual DbSet<HostelReg> HostelRegs { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LibraryBook> LibraryBooks { get; set; }
        public virtual DbSet<LibraryBookAvailability> LibraryBookAvailabilities { get; set; }
        public virtual DbSet<LibraryBookCatagory> LibraryBookCatagories { get; set; }
        public virtual DbSet<LibraryBookIssue> LibraryBookIssues { get; set; }
        public virtual DbSet<LibraryBookRequest> LibraryBookRequests { get; set; }
        public virtual DbSet<MainMenu> MainMenus { get; set; }
        public virtual DbSet<MenuAlocation> MenuAlocations { get; set; }
        public virtual DbSet<MenuSubMenu> MenuSubMenus { get; set; }
        public virtual DbSet<MenuSubMenuChild> MenuSubMenuChilds { get; set; }
        public virtual DbSet<OnlineExam> OnlineExams { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<StockCategory> StockCategories { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<StockMaster> StockMasters { get; set; }
        public virtual DbSet<StockPurchase> StockPurchases { get; set; }
        public virtual DbSet<StockPurchaseDetail> StockPurchaseDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectAllocation> SubjectAllocations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TC> TCs { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<TransportationFee> TransportationFees { get; set; }
        public virtual DbSet<TransportationFeesPaid> TransportationFeesPaids { get; set; }
        public virtual DbSet<TransportationRoute> TransportationRoutes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<vw_leavenewlist> vw_leavenewlist { get; set; }
        public virtual DbSet<vw_StudentTc> vw_StudentTc { get; set; }
        public virtual DbSet<vw_BookCategoryAvailability> vw_BookCategoryAvailability { get; set; }
        public virtual DbSet<vw_BookIssueAvail> vw_BookIssueAvail { get; set; }
        public virtual DbSet<vw_BooksDetails> vw_BooksDetails { get; set; }
        public virtual DbSet<vw_ClassRoomTeacherView> vw_ClassRoomTeacherView { get; set; }
        public virtual DbSet<vw_classTeacherEmail> vw_classTeacherEmail { get; set; }
        public virtual DbSet<vw_EmployeeLibraryBook> vw_EmployeeLibraryBook { get; set; }
        public virtual DbSet<vw_employeeownleave> vw_employeeownleave { get; set; }
        public virtual DbSet<vw_empsal> vw_empsal { get; set; }
        public virtual DbSet<vw_ExamMarkStudTeacher> vw_ExamMarkStudTeacher { get; set; }
        public virtual DbSet<vw_HostelFeePayment> vw_HostelFeePayment { get; set; }
        public virtual DbSet<vw_HostelRegView> vw_HostelRegView { get; set; }
        public virtual DbSet<vw_IndexEvent> vw_IndexEvent { get; set; }
        public virtual DbSet<vw_ListStockItem> vw_ListStockItem { get; set; }
        public virtual DbSet<vw_student_hostelfee_details> vw_student_hostelfee_details { get; set; }
        public virtual DbSet<vw_student_leave_view> vw_student_leave_view { get; set; }
        public virtual DbSet<vw_studenthostelfee> vw_studenthostelfee { get; set; }
        public virtual DbSet<vw_StudentLeaveApproval> vw_StudentLeaveApproval { get; set; }
        public virtual DbSet<vw_studentownleave> vw_studentownleave { get; set; }
        public virtual DbSet<vw_StudentParentView> vw_StudentParentView { get; set; }
        public virtual DbSet<vw_StudentTcDetails> vw_StudentTcDetails { get; set; }
        public virtual DbSet<vw_studenttransfees> vw_studenttransfees { get; set; }
        public virtual DbSet<vw_studenttransport> vw_studenttransport { get; set; }
        public virtual DbSet<vw_SubjectAllocationList> vw_SubjectAllocationList { get; set; }
        public virtual DbSet<vw_teacherownleave> vw_teacherownleave { get; set; }
        public virtual DbSet<vw_warden_namelist> vw_warden_namelist { get; set; }
    
        public virtual ObjectResult<FeeCalculation_Result> FeeCalculation(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FeeCalculation_Result>("FeeCalculation", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<FeeCalculation1_Result> FeeCalculation1(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FeeCalculation1_Result>("FeeCalculation1", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<GetAllUnpaidHostelFeesStudent_Result> GetAllUnpaidHostelFeesStudent(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUnpaidHostelFeesStudent_Result>("GetAllUnpaidHostelFeesStudent", studentIdParameter);
        }
    
        public virtual ObjectResult<GetFeeDisplay_Result> GetFeeDisplay(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeeDisplay_Result>("GetFeeDisplay", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<GetFeesDisplay_Result> GetFeesDisplay(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeesDisplay_Result>("GetFeesDisplay", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<GetFeesDisplay2_Result> GetFeesDisplay2(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeesDisplay2_Result>("GetFeesDisplay2", studentIdParameter, studentClassParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_leavenew()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_leavenew");
        }
    
        public virtual int sp_listallleave()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_listallleave");
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<TotalFees_Result> TotalFees(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TotalFees_Result>("TotalFees", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<TotalFeesCollection_Result> TotalFeesCollection(Nullable<int> studentId, Nullable<int> studentClass)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var studentClassParameter = studentClass.HasValue ?
                new ObjectParameter("StudentClass", studentClass) :
                new ObjectParameter("StudentClass", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TotalFeesCollection_Result>("TotalFeesCollection", studentIdParameter, studentClassParameter);
        }
    
        public virtual ObjectResult<TransportTotal_Result> TransportTotal(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TransportTotal_Result>("TransportTotal", studentIdParameter);
        }
    }
}