using PetPalsApp.DAO;
using PetPalsApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Main
{
    internal class program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Welcome to PetPals ***");
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Add new pet");
                Console.WriteLine("2. Update Existing pet");
                Console.WriteLine("3. Get all pets information");
                Console.WriteLine("4. Get pet information by ID");
                Console.WriteLine("5. Remove a pet from record");
                Console.WriteLine("6. Donate now");
                Console.WriteLine("7. Update Donation record");
                Console.WriteLine("8. Get List of all donations");
                Console.WriteLine("9. Get donation detail by ID");
                //Console.WriteLine("10. Get pet information by ID");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                PetsDao petsDao = new PetsDao();

                switch (choice)
                {
                    case "1":
                        AddNewPet();
                        break;

                    case "2":
                        UpdatePetInfo();
                        break;

                    case "3":
                        GetAllPets();
                        

                        break;

                    case "4":
                        GetPetInfoByID();
                        break;

                    case "5":
                        RemovePet();
                        break;

                    case "6":
                        RecordDonation();
                        break;

                    case "7":
                        UpdateDonationInfo();
                        break;

                    case "8":
                        GetAllDonations();
                        break;

                    case "9":
                        GetDonationInfoByID();
                        break;

                    case "10":
                        GetPetInfoByID();
                        break;

                    case "0":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        // Add a new pet
        static void AddNewPet()
        {
            Console.Clear();
            Console.WriteLine("Add New Pet");

            Console.Write("Enter Pet Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Breed: ");
            string breed = Console.ReadLine();

            Console.Write("Enter Type (Dog/Cat/etc.): ");
            string type = Console.ReadLine();

            Console.Write("Is the pet available for adoption (True/False): ");
            bool availableForAdoption = bool.Parse(Console.ReadLine());

            Console.Write("Enter Shelter ID: ");
            int shelterID = int.Parse(Console.ReadLine());

            Pets pet = new Pets
            {
                Name = name,
                Age = age,
                Breed = breed,
                Type = type,
                AvailableForAdoption = availableForAdoption,
                ShelterID = shelterID
            };

            PetsDao petDao = new PetsDao();
            petDao.SavePetInfo(pet);
            Console.WriteLine("Pet added successfully!");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Update pet information
        static void UpdatePetInfo()
        {
            Console.Clear();
            Console.WriteLine("Update Pet Information");

            Console.Write("Enter Pet ID to update: ");
            int petID = int.Parse(Console.ReadLine());

            PetsDao petDao = new PetsDao();
            Pets pet = petDao.GetPetInfoByID(petID);

            if (pet != null)
            {
                Console.Write("Enter new Name (leave blank to keep existing): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) pet.Name = newName;

                Console.Write("Enter new Age (leave blank to keep existing): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageInput)) pet.Age = int.Parse(ageInput);

                Console.Write("Enter new Breed (leave blank to keep existing): ");
                string newBreed = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBreed)) pet.Breed = newBreed;

                Console.Write("Enter new Type (leave blank to keep existing): ");
                string newType = Console.ReadLine();
                if (!string.IsNullOrEmpty(newType)) pet.Type = newType;

                Console.Write("Is the pet available for adoption (True/False, leave blank to keep existing): ");
                string adoptionInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(adoptionInput)) pet.AvailableForAdoption = bool.Parse(adoptionInput);

                petDao.UpdatePetInfo(pet);
                Console.WriteLine("Pet information updated successfully!");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Get all pets
        static void GetAllPets()
        {
            Console.Clear();
            PetsDao petDao = new PetsDao();
            List<Pets> petsList = petDao.GetAllPets();

            if (petsList.Count > 0)
            {
                Console.WriteLine("List of all Pets:");
                foreach (var pet in petsList)
                {
                    Console.WriteLine($"Pet ID: {pet.PetID}, Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}, Available for Adoption: {pet.AvailableForAdoption}");
                }
            }
            else
            {
                Console.WriteLine("No pets available.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Get pet information by ID
        static void GetPetInfoByID()
        {
            Console.Clear();
            Console.Write("Enter Pet ID: ");
            int petID = int.Parse(Console.ReadLine());

            PetsDao petDao = new PetsDao();
            Pets pet = petDao.GetPetInfoByID(petID);

            if (pet != null)
            {
                Console.WriteLine($"Pet ID: {pet.PetID}, Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}, Available for Adoption: {pet.AvailableForAdoption}");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Remove pet from record
        static void RemovePet()
        {
            Console.Clear();
            Console.Write("Enter Pet ID to remove: ");
            int petID = int.Parse(Console.ReadLine());

            PetsDao petDao = new PetsDao();
            bool success = petDao.DeletePetInfo(petID);

            if (success)
            {
                Console.WriteLine("Pet removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove pet. Please try again.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Record a donation
        static void RecordDonation()
        {
            Console.Clear();
            Console.WriteLine("Donate Now");

            Console.Write("Enter Donor's Name: ");
            string donorName = Console.ReadLine();

            Console.Write("Enter Donation Type (Cash/Item): ");
            string donationType = Console.ReadLine();

            Console.Write("Enter Donation Amount (Leave blank for item donations): ");
            string amountInput = Console.ReadLine();
            decimal? donationAmount = string.IsNullOrEmpty(amountInput) ? null : (decimal?)Convert.ToDecimal(amountInput);

            Console.Write("Enter Donation Item (Leave blank for cash): ");
            string donationItem = Console.ReadLine();

            Donation donation = new Donation
            {
                DonorName = donorName,
                DonationType = donationType,
                DonationAmount = donationAmount,
                DonationItem = donationItem,
                DonationDate = DateTime.Now
            };

            DonationDao donationDao = new DonationDao();
            donationDao.SaveDonationInfo(donation);
            Console.WriteLine("Donation recorded successfully!");

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Update donation information
        static void UpdateDonationInfo()
        {
            Console.Clear();
            Console.Write("Enter Donation ID to update: ");
            int donationID = int.Parse(Console.ReadLine());

            DonationDao donationDao = new DonationDao();
            Donation donation = donationDao.GetDonationInfoByID(donationID);

            if (donation != null)
            {
                Console.Write("Enter new Donor's Name (leave blank to keep existing): ");
                string newDonorName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDonorName)) donation.DonorName = newDonorName;

                Console.Write("Enter new Donation Amount (leave blank to keep existing): ");
                string amountInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(amountInput)) donation.DonationAmount = decimal.Parse(amountInput);

                Console.Write("Enter new Donation Item (leave blank to keep existing): ");
                string newDonationItem = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDonationItem)) donation.DonationItem = newDonationItem;

                donationDao.UpdateDonationInfo(donation);
                Console.WriteLine("Donation information updated successfully!");
            }
            else
            {
                Console.WriteLine("Donation not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Get all donations
        static void GetAllDonations()
        {
            Console.Clear();
            DonationDao donationDao = new DonationDao();
            List<Donation> donations = donationDao.GetAllDonations();

            if (donations.Count > 0)
            {
                Console.WriteLine("List of all Donations:");
                foreach (var donation in donations)
                {
                    Console.WriteLine($"Donation ID: {donation.DonationID}, Donor: {donation.DonorName}, Amount: {donation.DonationAmount ?? 0:C}, Item: {donation.DonationItem}");
                }
            }
            else
            {
                Console.WriteLine("No donations recorded.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Get donation information by ID


        static void GetDonationInfoByID()
        {
            Console.Clear();
            Console.Write("Enter Donation ID: ");
            int donationID = int.Parse(Console.ReadLine());

            DonationDao donationDao = new DonationDao();
            Donation donation = donationDao.GetDonationInfoByID(donationID);

            if (donation != null)
            {
                Console.WriteLine($"Donation ID: {donation.DonationID}, Donor: {donation.DonorName}, Amount: {donation.DonationAmount ?? 0:C}, Item: {donation.DonationItem}");
            }
            else
            {
                Console.WriteLine("Donation not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }



}
