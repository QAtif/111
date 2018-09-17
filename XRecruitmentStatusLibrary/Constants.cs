
namespace XRecruitmentStatusLibrary
{

    public class Constants
    {
        public enum CandidateLifeCycleStatus
        {
            PreSignupSignupPending = 1003,
            MigratedDataFormPending = 1005,
            SignupdoneFormPending = 1010,
            VerificationDoneApplicationPending = 1012,
            ProfileStartedApplicationPending = 1015,
            ProfileCompletedEducationPending = 1018,
            ApplicationSubmittedProfileMappingPending = 1020,
            ApplicationCompletedProfileNotMapped = 1030,
            PositionMappedWaitingforPositionopening = 1040,
            ShortlistedSchedulingPendingTest = 1050,
            SchedulingdoneTestPending = 1060,
            TestnotAppearedReSchedulingPending = 1070,
            TestReportingdoneTestPending = 1080,
            TestDoneResultPending = 1100,
            TestPassedSchedulingPendingInterview = 1110,
            NoTestSchedulingPendingInterview = 1120,
            TestFailedReSchedulingPendingTest = 1130,
            SchedulingDoneInterviewPending = 1140,
            InterviewDoneResultPending = 1145,
            InterviewnotAppearedReSchedulingPending = 1150,
            InterviewDoneOfferGenerated = 1155,
            InterviewPassedOfferGenerationPending = 1160,
            InterviewFailedReSchedulingPending = 1170,
            OfferGeneratedSchedulingPending = 1180,
            OfferSchedulingDoneOfferPending = 1190,
            OfferDeliveredAcceptancePending = 1200,
            OfferAcceptedVerificationSchedulingPending = 1210,
            OfferNotAcceptedReSchedulingPendingOffer = 1220,
            VerificationSchedulingDoneVerficationPending = 1225,
            VerificationDoneAppointmentSchedulingPending = 1230,
            AppointmentSchedulingDoneJoiningReportingPending = 1235,
            InValidDocuments = 1240,
            MedicalFailed = 1245,
            JoiningReportingDoneHiredportalactivated = 1250,
            HiredBenefitAcknowledgmentPending = 1260,
            HiredBenefitsAcknowledged = 1270,
            Resigned = 1280,
        }

        public enum CandidateProfileStatus
        {
            ProfilePending = 2010,
            FilledProfessionalExperienceEducationalQualificationPending = 2020,
            NoProfessionalExperienceEducationalQualificationPending = 2021,
            FilledEducationalQualificationDiplomaPending = 2030,
            FilledDiplomaQualificationCertificatePending = 2040,
            NoDiplomaQualificationCertificatePending = 2041,
            FilledCertificateQualificationSkillSetPending = 2050,
            NoCertificateQualificationSkillSetPending = 2051,
            MarkedSkillSetPortfolioPending = 2060,
            PortfolioBrowsedPersonalDetailPending = 2070,
            NoPortfolioBrowsedPersonalDetailPending = 2071,
            FilledPersonalDetailsReferralPending = 2080,
            ReferralsDoneDocumentsUploadingPending = 2090,
            DocumentsUploadedProfileCompleted = 2100,
            ProfileDone = 2110,
        }

        public enum ProfileNavigation
        {
            ProfessionalExperience = 1,
            EducationalQualification = 2,
            Diploma = 3,
            Certification = 4,
            SkillSet = 5,
            Portfolio = 6,
            PersonalDetails = 7,
            WheredidyouhearaboutAxactReferral = 8,
            UploadDocuments = 9,
            FamilyDetails = 10,
        }

        public enum CandidateMetaStatus
        {
            SignUp = 101010,
            FillApplicationForm = 101020,
            EvaluationTestInPerson = 101030,
            Interview = 101040,
            OfferLetter = 101050,
            DocumentSubmission = 101060,
            DocumentMedicalVerification = 101070,
            JoiningDate = 101080,
        }

        public enum CandidateAlert
        {
            FillApplicationForm = 1,
            ScheduleYourTest = 2,
            TestScheduledReminder = 3,
            InterviewScheduledReminder = 4,
            Offer = 5,
        }

        public enum CandidateSMS
        {
            FillApplicationForm = 1,
            ScheduleYourTest = 2,
            TestScheduledReminder = 3,
            InterviewScheduledReminder = 4,
            Offer = 5,
            VerificationDoneAppointmentSchedulingPending = 6,
        }

        public enum CandidateEmail
        {
            OnSignUp = 1,
            CandidateProfileSequenceEnd = 2,
            ShortlistingScreen = 3,
            SchedulingScreenTestPending = 4,
            TestModuleTestPass = 5,
            TestModuleNoTest = 6,
            SchedulingScreenTestFail = 7,
            ScheduledCandidateInterviewPending = 8,
            CandidateDetailsInterviewPass = 9,
            CandidateDetailsInterviewFail = 10,
            CandidateDetailsOfferPending = 11,
        }

        public enum RequisitionStatus
        {
            DOApprovalPending = 10,
            DORejected = 20,
            HRDOApprovalPending = 30,
            HRDOReject = 40,
            OPDApprovalPending = 50,
            OPDReject = 60,
            OPDApprove = 70,
        }

        public enum OfferApprovalStatus
        {
            HRPDApprovalPending = 10,
            HRPPDRejected = 20,
            DOApprovalPending = 30,
            DORejected = 40,
            OPDApprovalPending = 50,
            OPDRejected = 60,
            AutidApprovalPending = 70,
            Approved = 80,
            Rejected = 90,
        }

        public enum ModuleCode
        {
            NoModule = 0,
            LifeCycleStatus = 1000,
            ProfileStatus = 2000,
            MetaApplicationStatus = 100000,
        }

        public enum EducationalPrograms
        {
            Doctorate = 1,
            Master = 2,
            Bachelor = 3,
            Intermediate = 4,
            Matric = 5,
            Diploma = 6,
            Certificate = 7,
        }

        public enum UserTypeCode
        {
            Admin = 1,
            Candidate = 2,
            DomainOwner = 3,
            CategoryHead = 4,
            CategoryResource = 5,
            CRMHead = 6,
            CRMResource = 7,
            DomainOwnerOtherDept = 9,
            TeamCoordinatorOtherDept = 10,
            VerificationUsersAPM = 11,
            OPD = 13,
            Brand = 14,
            Graphics = 15,
            Audit = 17,
        }

        public enum SignupThrough
        {
            Candidate = 1,
            AdminUser = 2,
        }

        public enum CRMServiceFunction
        {
            AddCandidateInfo = 1,
            ForgotPassword = 2,
            EmailVerification = 3,
            SMSPhoneVerification = 4,
            SMSStatusBased = 5,
        }

        public enum Client
        {
            AxactRecruitmentSystem = 1,
        }
    }
}




