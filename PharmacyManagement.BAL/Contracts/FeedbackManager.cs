using PharmacyManagement.BAL.Services;
using PharmacyManagement.DAL.DataAccess.Interface;
using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Contracts
{

    public class FeedbackManager : IFeedbackManager
    {
        private readonly IDataAccess _um;



        public FeedbackManager(IDataAccess um)
        {
            _um = um;
        }



        public async Task<bool> AddAsync(Feedback feedback)
        {
            try
            {
                if (feedback != null)
                {
                    // Create a temporary driver object with the provided data
                    Feedback tempFeedback = new Feedback
                    {
                        Feedback_id = feedback.Feedback_id,
                        Service_rating = feedback.Service_rating,
                        Feedbacks = feedback.Feedbacks,
                    };



                    // Add the temporary driver to the data access layer and save changes
                    _um.Feedbacks.Addsync(tempFeedback);
                    await _um.SaveAsync();



                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }



        }



     

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _um.Feedbacks.GetAllAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByIdAsync(int id)
        {
            {
                // Retrieve an driver with the specified ID from the data access layer
                var feedback = await _um.Feedbacks.GetFirstorDefaultAsync(t => t.Feedback_id == id);



                // Return the driver if found, otherwise return an empty list
                return feedback != null ? new List<Feedback> { feedback } : Enumerable.Empty<Feedback>();
            }
        }

        public async Task Remove(int id)
        {
            // Retrieve the driver with the specified ID from the data access layer
            var feedback = await _um.Feedbacks.GetFirstorDefaultAsync(t => t.Feedback_id == id);



            if (feedback != null)
            {
                // Remove the driver from the data access layer and save changes
                _um.Feedbacks.Remove(feedback);
                _um.Save();
            }
        }



        public async Task UpdateExisting(Feedback feedback)
        {
            // Update the existing driver in the data access layer and save changes
            _um.Feedbacks.updateExisting(feedback);
            await _um.SaveAsync();
        }
    }
}

