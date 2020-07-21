using System.Collections.Generic;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Models.ViewModel;

namespace ViewingsApp.Services
{
    public interface IBookingValidator
    {
        BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties);
    }
    
    public class BookingValidator : IBookingValidator
    {
        public BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties)
        {

            if (isNameInvalid(bookingRequest))
            {
                return new BookingValidation
                {
                    IsValid = false,
                    ErrorMessage = "You must provide a name."
                };
            }
          
            if (isEmailInvalid(bookingRequest))
            {
                return new BookingValidation
                {
                    IsValid = false,
                    ErrorMessage = "You must provide an email address."
                };
            }

            return new BookingValidation
            {
                IsValid = true,
                ErrorMessage = ""
            };
        }

        // Method to check if name is missing
        private bool isNameInvalid(BookingRequest bookingRequest)
        {
            return bookingRequest.Name == "";  
        }

        // Method to check if email is missing
        private bool isEmailInvalid(BookingRequest bookingRequest)
        {
            return bookingRequest.EmailAddress == "";  
        }


    }
}