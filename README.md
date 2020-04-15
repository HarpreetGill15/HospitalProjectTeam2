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
        
        
        
     
        
