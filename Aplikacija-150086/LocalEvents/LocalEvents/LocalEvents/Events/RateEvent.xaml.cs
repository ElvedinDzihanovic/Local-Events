using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCL.Models;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalEvents.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RateEvent : ContentPage
	{
        private WebAPIHelper eventToVisitService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventToVisit");
        private EventToVisit editEvent { get; set; }
        private int eventID { get; set; }

        public RateEvent (int eventId)
		{
			InitializeComponent ();
            eventID = eventId;

            BindEvent();
        }

        private void BindEvent()
        {
            System.Net.Http.HttpResponseMessage response = eventToVisitService.GetTwoParameterResponse("GetDetails", Global.PrijavljeniKorisnik.KorisnikID.ToString(), eventID.ToString());

            if (response.IsSuccessStatusCode)
            {
                
                var jsonObject = response.Content.ReadAsStringAsync();

                if(jsonObject.Result != "null") { 
                editEvent = JsonConvert.DeserializeObject<PCL.Models.EventToVisit>(jsonObject.Result);

                    //DisplayAlert(editEvent.EventID.ToString(), "success", "success");

                    ratingPickLabel.Text = "Rate event: ";
                    commentInputLabel.Text = "Comment: ";


                    var ratingList = new List<string>();

                    
                    ratingList.Add("★");
                    ratingList.Add("★★");
                    ratingList.Add("★★★");
                    ratingList.Add("★★★★");
                    ratingList.Add("★★★★★");

                    picker.ItemsSource = ratingList;
                   

                    picker.TextColor = Color.Red;

                    //provjeriti radi li ovo!!!
                    if (editEvent.EventRating != null)
                        picker.SelectedIndex = (editEvent.EventRating.Value - 1);
                    /*
                if (editEvent.EventRating == null)
                    ratingInput.Text = "0";
                else
                    ratingInput.Text = editEvent.EventRating.Value.ToString();
                    */

                    if (!String.IsNullOrEmpty(editEvent.Comment) && editEvent.Comment != "nullcomment") {
                        commentInput.Text = editEvent.Comment;

                        
                    }
                }

                submitBtn.Text = "Submit";
            }
            else
                DisplayAlert("error", "error", "error");
            
        }
        
        

        private void submitBtn_Clicked(object sender, EventArgs e)
        {
            //ide od -1 (ako nista nije odabrano) pa nadalje...
            //DisplayAlert("picked", picker.SelectedIndex.ToString(), "ok");

            string komentar;

            if (String.IsNullOrEmpty(commentInput.Text))
                komentar = "nullcomment";
            else
                komentar = commentInput.Text; //komentar = JsonConvert.SerializeObject(commentInput.Text);

            

            EventToVisit etv = new EventToVisit
            {
                Comment = komentar,
                CommentDate = DateTime.Now,
                EventRating = picker.SelectedIndex + 1, //npr. index 0 + 1 = ocjena 1 star
                RatingDate = DateTime.Now,
                EventID = editEvent.EventID,
                PosjetilacID = Global.PrijavljeniKorisnik.KorisnikID
            };
            
            
            System.Net.Http.HttpResponseMessage response = eventToVisitService.GetMultipleParameterResponse("UpdateEventToVisit", etv.PosjetilacID.ToString(), etv.EventID.ToString(), etv.EventRating.ToString(), komentar);



            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success!", "Successfully rated event!", "Ok");
            }
            else
                DisplayAlert("Error", response.StatusCode.ToString(), "Close");
    

        }
    }
}