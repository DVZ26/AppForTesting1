namespace MedicalAppTests
{
    using MedicalApp.Models;
    public class Tests
    {

        [Test]
        public void DoctorAddSpecializationValid()
        {
            //Arange
            Doctor testDoctor = new Doctor("TestName");
            string testSpecialization = "General";
            string response;

            //Act
            response=testDoctor.AddSpecialization(testSpecialization);

            //Assert
            Assert.AreEqual(response, testSpecialization);

        }
    }
}