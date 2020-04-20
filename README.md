# HospitalProjectTeam2

## Harpreet Gill (n01241421)
1. ### Notification Feature 
    #### Progress
      - Models
        - Notifications
        - NotificationTypes
        - View Models
          - UpdateNotification
      - Views
        - Add
          - Where admin can add a notificaiton
        - List
          - List of all notifications
          - Delete any notifications
        - Update
          - Update a notification information
          - Set it to inactive
        - ShowOnHome 
          - View to show on the home page just the alert notification with the title and content
      - Controller
        - NotificationsController
2. ### Feedbacks Feature
    #### Progress
      - Models
        - Departments
        - Feedbacks
        - FeedbackTypes
        - View Models
          - Add Department
          - Show Department
          - ShowFeedbackType
          - UpdateFeedback
      - Views
        - Feedbacks
          - Add
            - Where user can add a feedback
          - List
            - List of all feedbacks
            - Delete any feedback
          - Update
            - Update a feedback information
          - ShowType 
            - View to show a feedback type information with assosiated departments and feedbacks for this type
          - AddDepartment
            - View to add a department to a feedback type
        - Departments
          - Add
            - Where admin can add a department
          - List 
            - List of all departments
            - delete department
          - Show
            - Show department information and feedbacktypes assosiated
          - Update
            - Update department information
      - Controller
        - FeedbacksController
        - DepartmentsController
        
## Elmira Alif (n01318198)
1. ### MVP feature 
    #### Progress
      - Models
        - Blog.cs
      - Views
        - Home (Index): Design and stylesheet 
        - Shared/_Layout: Master Layout
        - Blogs/List : List the blogs to the user
        - Blogs/ListAdmin: List blogs to be managed by the admin
        - Blogs/Add : Add a new blog by the admin
        - Blogs/Update: Update the blog post by the admin
        - Blogs/ConfirmDelete: confirmation to delete by the admin
      - Controllers
        - BlogsController
2. ### Donation feature 
    #### Progress
    - Models
        - Donation.cs
        - Designation.cs
        - Province.cs
        - ViewModels
            - NewDonationViewModel.cs
    - Views
        - Donations/Add : To fill out the form of donation
        - Donation/List: List all the donations made 
        - Donation/Show: Details of the donation
        - Donation/Update: To update the personal infromation on the form
        - Donation/ConfirmDelete: Confirmation to delete
    - Controllers
        - DonationsController
        
 ## Arun Rathinam (n01358379)
1. ### Careers (Job Portal) Feature 
    #### Progress
      - Models
        - Job
        - Applications
        - View Models
          - JobApplications
          - JobsApplications
          
      - Views
        - Job
            - Job/AddJobAdmin
              - Where admin can add a new job
            - Job/ApplyJobAdmin
              - Where the admin can apply for a job (Includes Resume upload)
            - Job/ListJobsAdmin
              - Admin can see list of jobs
              - Navigate to Add/Update/Apply/View pages
              - Delete a particular job
            - Job/ShowJobAdmin 
              - Admin can see list of applications for the particular job
              - Admin can see the job details
              - Admin can download the resume of a particular applicant
              - Admin can reject an application
            - Job/UpdateJobAdmin
              - Admin can update a particular job
            - Job/ListJobs
              - User can see the list of jobs in the hospital
              - User can View a particular job
            - Job/ShowJib
              - User can see the details of a particular job
              - User can apply for a job
            - Job/ApplyJob
              - User can apply for a particular job
              - Resume Upload feature included. 
        - Application
            - Application/AddApplicationAdmin
              - Admin can add a new application
            - Application/ListApplicationsAdmin
              - Admin can see the list of all applications
              - Admin can download the resume of a particular applicant
              - Admin has navigation links to Update/View pages
              - Admin can reject a particular application
            - Application/ShowApplicationAdmin
              - Shows details of a particular application
              - Admin can View/Download resume. 
              - Admin can reject the application
            - Application/UpdateApplicationAdmin
              - Admin can update a particular application
        
          
      - Controller
        - JobController
        - ApplicationsController
2. ### FAQ Feature
    #### Progress
      - Models
        - FrequentlyAskedQUestion
      
      - Views
        - FrequentlyAskedQuestion
          - AddFAQAdmin
            - Admin can add a new FAQ
          - ListFAQAdmin
            - Admin can see the list of FAQs
            - Has navigation links to Add,Delete,Update FAQ
          - UpdateFAQAdmin
            - Admin can update the details of a particular FAQ
          - List/FAQ 
            - Users can see the list of FAQs
            
      - Controller
        - FrequentlyAskedQuestionControllerr
        
        BalmeetKaur(N01360420)
        Progress
        1.) Patient Registration System
        Models
             PatientsRegistration.cs 
        Views
             PatientsRegistration
                                  Add.cshtml = patients can add his details by filling out a form
                                  DeleteConfirm.cshtml = Admin can delete records of patient
                                  Edit.cshtml = Admin can edit records of a particular patient
                                  List.cshtml = Admin can view lists of all patients in a system
                                  Show.cshtml = admin can view details of a particular patient
        Controller
                 PatientsRegistrationController.cs
                 
       2.) Tips and Advices for Diseases
       Models
             Diseases.cs
             Tips.cs
       ViewModels
                 EditDisease.cs
                 ShowDisease.cs
       Views
            Diseases
                    Add.cshtml = admin can diseases  by filling out a form
                    DeleteConfirm.cshtml = Admin can delete details of disease
                    Edit.cshtml = Admin can edit details of a particular disease
                    List.cshtml = Admin can view lists of all diseases in a system
                    Show.cshtml = admin can view details of a particular disease
                    PatientView.cshtml = patients can view tips and advices for diseases
           Tips
               Add.cshtml = admin can add tips for diseases
               DeleteConfirm.cshtml = admin can delete a particular tip
               Edit.cshtml = admin can edit details of tips
               List.cshtml = admin can view list of all tips
               Show.cshtml = admin can view content of particular tip
                    
        
     
        
