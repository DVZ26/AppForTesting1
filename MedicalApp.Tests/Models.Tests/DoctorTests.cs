using MedicalApp.Models;

namespace MedicalApp.Tests.Models.Tests
{
    public class DoctorTests
    {
        [Test]
        public void DoctorAddSpecializationValidSpecialization()
        {
            //Arange
            Doctor testDoctor = new Doctor("TestName");
            string testSpecialization = "General";
            string response;

            //Act
            response = testDoctor.AddSpecialization(testSpecialization);

            //Assert
            Assert.AreEqual(response, testSpecialization);

        }

        [Test]
        public void DoctorAddSpecializationSpecilizaionIsEmpty()
        {
            //Arange
            Doctor doctor = new Doctor("TestName");
            string testSpecialization = "";
            string response;
            string expectedResponse = "Lenght can't be less then 5";

            //Act
            response = doctor.AddSpecialization(testSpecialization);

            //Assert
            Assert.AreEqual(expectedResponse, response);

        }

        [Test]
        public void DoctorAddSpecializationWithLenghtBetween0and5()
        {
            //Arange
            Doctor doctor = new Doctor("TestName");
            string testSpecialization="Gen";
            string response;
            string expectedResponse = "Lenght can't be less then 5";

            //Act
            response = doctor.AddSpecialization(testSpecialization);

            //Assert
            Assert.AreEqual(expectedResponse, response);
        }


        [Test]
        public void Doctor_AddPatientToList_PacientReasonForIntenationMatchesSpecialization_IsTheFirst()
        {
            string testSpecialization = "Ortopedie";
            Patient patient = new Patient(1,"Mihai", testSpecialization);
            Doctor doctor = new Doctor("Doctor");
            doctor.AddSpecialization(testSpecialization);
            string response;


            response = doctor.AddPatientToList(patient);


            Assert.AreEqual("First patient added", response);
        }

        [Test]
        public void Doctor_AddPatientToList_PacientReasonForIntenationMatchesSpecialization_IsTheSecond()
        {
            string testSpecialization = "Ortopedie";
            Patient patient1 = new Patient(1, "Mihai", testSpecialization);
            Patient patient2 = new Patient(2, "Goerge", testSpecialization);

            Doctor doctor = new Doctor("Doctor");
            doctor.AddSpecialization(testSpecialization);
            string response;

            doctor.AddPatientToList(patient1);
            response = doctor.AddPatientToList(patient2);


            Assert.AreEqual("Patient added", response);
        }

        [Test]
        public void Doctor_AddPatientToList_PacientReasonForIntenationMatchesSpecialization_NoMoreSlotsLeft()
        {
            string testSpecialization = "Ortopedie";
            Patient patient1 = new Patient(1, "Mihai", testSpecialization);
            Patient patient2 = new Patient(2, "Goerge", testSpecialization);

            Doctor doctor = new Doctor("Doctor");
            doctor.NrOfPatients = 1;
            doctor.AddSpecialization(testSpecialization);
            string response;

            doctor.AddPatientToList(patient1);
            response = doctor.AddPatientToList(patient2);


            Assert.AreEqual("No more slots left", response);
        }

        [Test]
        public void Doctor_AddPatientToList_PacientReasonForIntenationDoesNotMatchSpecialization()
        {
            Patient patient = new Patient(1, "Mihai", "Ortopedie");
            Doctor doctor = new Doctor("Doctor");
            doctor.AddSpecialization("Cardiolog");
            string response;


            response = doctor.AddPatientToList(patient);


            Assert.AreEqual("Needs a different specialization", response);
        }

    }
}