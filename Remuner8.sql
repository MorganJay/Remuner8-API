 USE db_payrollapp;
 CREATE TABLE Passwords(
                email VARCHAR(50) NOT NULL UNIQUE PRIMARY KEY,
                password VARCHAR(32) NOT NULL
);
CREATE TABLE PensionFundAdministration(
				pfaCode VARCHAR(10) PRIMARY KEY NOT NULL,
				pfaName VARCHAR(50) NOT NULL,
				accountNumber VARCHAR(10) NOT NULL,
				address VARCHAR(200) NOT NULL
);
CREATE TABLE Departments(
               departmentId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
               departmentName VARCHAR(50) NOT NULL
);

CREATE TABLE JobDescriptions(
              jobDescriptionId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
              jobDescriptionName VARCHAR(50) NOT NULL,
              basicSalary DECIMAL(19,4) NOT NULL,
              housingAllowance DECIMAL(19,4) NOT NULL,
              transportAllowance DECIMAL(19,4) NOT NULL
);
CREATE TABLE Bonuses(
               jobDescriptionId INT NOT NULL,
               departmentId INT  NOT NULL,
               bonusName DECIMAL(19,4) NOT NULL,
               amount DECIMAL(19,4) NOT NULL,
               FOREIGN KEY (departmentId) REFERENCES Departments(departmentId),
               FOREIGN KEY (jobDescriptionId) REFERENCES JobDescriptions(jobDescriptionId)
);

 CREATE TABLE SystemDefaults(
              companyName VARCHAR(30) NOT NULL,
              address VARCHAR(200) NOT NULL,
              email  VARCHAR(50) NOT NULL,
              officialPhoneNumber VARCHAR(15) NOT NULL,
              mobileNumber VARCHAR(15)  ,
              websiteURL VARCHAR(100) NOT NULL ,
              postalCode VARCHAR(7) ,
			  maxSalaryDays INT NOT NULL,
              salaryStartDate DATE NOT NULL,
              salaryEndDate DATE NOT NULL
 );
 CREATE TABLE UserRoles(
			 id  INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
             role VARCHAR(30) NOT NULL UNIQUE
 );
 CREATE TABLE Banks(
			bankCode VARCHAR(10) PRIMARY KEY NOT NULL,
            bankName VARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE EmploymentType(
			employmentTypeId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
            employmentName VARCHAR(50) NOT NULL UNIQUE
 );
 
 CREATE TABLE EmployeeBiodata (
	        employeeId VARCHAR(10) PRIMARY KEY NOT NULL, 
            avatar MEDIUMBLOB,
			firstName VARCHAR(50) NOT NULL,
			lastName VARCHAR(50) NOT NULL, 
            otherName VARCHAR(50) NOT NULL,
            dateOfBirth DATE NOT NULL,
            address VARCHAR(200) NOT NULL,
            phoneNumber VARCHAR(20) NOT NULL UNIQUE,
            emailAddress VARCHAR(40) NOT NULL UNIQUE,
            gender CHAR(6) NOT NULL, 
			countryName VARCHAR(30) NOT NULL,
            stateName VARCHAR(30) NOT NULL,
            maritalStatus CHAR(12) NOT NULL,
			departmentId INT NOT NULL,
            jobDescriptionId INT NOT NULL,
            dateEmployed DATE NOT NULL,
            otherAllowances DECIMAL(10, 4),
            grossSalary DECIMAL(19,4) NOT NULL, 
            bankCode VARCHAR(10) NOT NULL,
            accountNumber VARCHAR(10) NOT NULL,
            FOREIGN KEY (departmentId) REFERENCES Departments(departmentId),
            FOREIGN KEY (jobDescriptionId) REFERENCES JobDescriptions(jobDescriptionId),
			FOREIGN KEY (bankCode) REFERENCES Banks(bankCode),
            FOREIGN KEY (emailAddress) REFERENCES Passwords(email)
);
CREATE TABLE StatutoryDeductions(
              statutoryTypeId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
              staffId VARCHAR(10) NOT NULL,
              amount1 DECIMAL(19,4) NOT NULL,
              amount2 DECIMAL(19,4) NOT NULL,
              pfaCode VARCHAR(10) NOT NULL ,
              pfaAccountNumber VARCHAR(10) NOT NULL,
              pfaAccountNumber1 VARCHAR (10) NOT NULL,
              description TEXT NOT NULL,
              FOREIGN KEY (staffId) REFERENCES EmployeeBiodata(employeeId),
              FOREIGN KEY (pfaCode) REFERENCES PensionFundAdministration(pfaCode)
);
CREATE TABLE PayrollTransactions(
			staffId VARCHAR(10) NOT NULL,
			transactionId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
			transactionDateTime DATETIME NOT NULL,
			deduction BOOL NOT NULL,
			principal DECIMAL(15,2) NOT NULL,
			rate DECIMAL(3,2) NOT NULL,
			balance DECIMAL(15,2) NOT NULL,
			statutory BOOL NOT NULL,
			FOREIGN KEY (staffId) REFERENCES EmployeeBiodata(employeeId)
);
CREATE TABLE TimeSheet(
			staffId VARCHAR(10) NOT NULL,
			date DATE NOT NULL,
			timeIn TIME ,
			timeOut TIME ,
			hoursWorked TIME,
			FOREIGN KEY (staffId) REFERENCES EmployeeBiodata(employeeId)
 );
 CREATE TABLE Taxes(
	        staffId VARCHAR(10) NOT NULL UNIQUE,
            PAYE DECIMAL(19,4),
            pension DECIMAL(19,4),
            FOREIGN KEY (staffId) REFERENCES EmployeeBiodata(employeeId) 
);


