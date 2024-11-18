#Features
1. Admin Panel
#Vacancy Management:
Create, update, and delete vacancies.
Associate vacancies with categories.
#Category Management:
Create and manage job categories.
Track the number of vacancies per category.
#Test Management:
Add, update, and delete test questions for each vacancy.
Track correct and incorrect answers for test results.
#Dashboard:
View the category with the most job listings.
View the most applied job vacancy.
#Analyze test results with detailed reports and graphical representations.
2. Candidate Interface
#Vacancy Listing:
View active vacancies with descriptions and "Apply" buttons.
#Application Process:
Apply for a job by filling out a form (name, email, phone).
Receive feedback with a success message after submission.
#Online Test:
Take an assessment with time limits for each question.
Navigate to the next question automatically when the time expires.
No ability to return to previous questions.
#Test Results:
View detailed results after completing the test (correct, incorrect, and unanswered questions).
Upload a CV after completing the test.


#Technology Stack
#Backend
Framework: ASP.NET Core MVC
ORM: Entity Framework Core
Database: MS SQL Server
F#rontend
HTML/CSS/JavaScript
#Libraries:
Chart.js: For graphical representation of test results.
Bootstrap: For responsive and styled components.
#Tools
IDE: Visual Studio
Package Manager: NuGet
Version Control: Git



#Installation
Clone the Repository:

bash
Copy code
git clone https://github.com/your-repo/vacancy-management-system.git
Setup the Database:

#Configure the connection string in appsettings.json:
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=VacancyManagementDb;Trusted_Connection=True;"
}
#Apply migrations:
bash
Copy code
dotnet ef database update


#Usage
#Admin Panel
#Navigate through the admin dashboard to manage vacancies, categories, and tests.
#View detailed test results and graphical summaries.
#Candidate Interface
#Browse the list of vacancies on the homepage.
Apply for a vacancy and complete the test.
Upload a CV after completing the test.
#Features in Detail
1. Test Results with Graphs
Pie Chart: Displays the percentage of correct, incorrect, and unanswered questions.
Detailed Table: Shows each question with the candidate's answer and whether it was correct.
2. Responsive Design
Mobile-friendly layout for candidate applications and test-taking.
Clean and professional admin dashboard.
3. Validation and Security
Input validation for forms (email, phone format).
File validation for CV uploads (only PDF/DOCX, max size 5MB).
Screenshots
1. Candidate Vacancy Page

2. Admin Dashboard

3. Test Results with Pie Chart

Future Enhancements
Add multi-language support.
Integrate email notifications for application submissions.
Implement advanced reporting features for admin users.
Contributors
Project Lead: Your Name
Backend Developer: Your Name
Frontend Developer: Your Name
