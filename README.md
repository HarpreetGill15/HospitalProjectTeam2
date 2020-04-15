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
