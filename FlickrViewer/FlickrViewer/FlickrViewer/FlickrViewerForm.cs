using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlickrViewer
{
   public partial class FlickrViewerForm : Form
   {
        // Use your Flickr API key here--you can get one at:
        // http://www.flickr.com/services/apps/create/apply
        //key="1a537765a2825f8302f25844ed037551"
        //secret key=="393af6ac582ea3d5" 

        private const string KEY = "1a537765a2825f8302f25844ed037551";

        // Create an WebClient object called flickrClient to invoke Flickr web service 

        private WebClient flickrClient= new WebClient();
       

        //Initialize a Task<String> object called flickrTask to null - Task<string> that queries Flickr

        Task<string> flickrTask = null;// Task<string> that queries Flickr
      
      public FlickrViewerForm()
      {
         InitializeComponent();
      } // end constructor

      // The method searchButton_Click initiates the asynchronous Flickr search query; 
      // display results when query completes
      private async void searchButton_Click( object sender, EventArgs e )
      {
         // Check whether user started a search previously (i.e., flickrTask is not null and the prior search has not completed) and,
         //if so, whether that search is already completed. 
         if (flickrTask!=null &&
            flickrTask.Status != TaskStatus.RanToCompletion )
         { //If an existing search is still being performed, the program displays a dialog asking if user wish  to cancel the search. 
            var result = MessageBox.Show( 
               "Cancel the current Flickr search?",
               "Are you sure?", MessageBoxButtons.YesNo, 
               MessageBoxIcon.Question );

                // If user clicks No, the event handler simply returns. Otherwise, the program calls  the WebClient's  CancelAsync 
                //method to terminiate the search.
                if (result == DialogResult.No)
                    return;
                else
                    flickrClient.CancelAsync(); // cancel current search
         } // end if

         //Create a URL for invoking the Flickr web service's method flickr.photos.search.
        //with Key you get from the Flickr website,tag, tag_mode=all, per_page = 500 and 
        //privacy_filter=1. Use the inputTextBox.Text.Replace(" ", ",") for tag.
         var flickrURL = string.Format(" https://api.flickr.com/services"+
             "/rest/?method=flickr.photos.search&api_key={0}&tags={1}"+
             "&tag_mode=all&privacy_filter=1&per_page=500&format=rest",
             KEY, inputTextBox.Text.Replace(" ", ","));

         imagesListBox.DataSource = null; // remove prior data source
         imagesListBox.Items.Clear(); // clear imagesListBox
         pictureBox.Image = null; // clear pictureBox
         imagesListBox.Items.Add( "Loading..." ); // display Loading...

         try
         {
                // Call WebClient's DownloadStringTaskAsync method using the flickrURL specified as the method's string argument to request information from
                // the server. Assign the task returned from the method to flickrTask.
                flickrTask = flickrClient.DownloadStringTaskAsync(flickrURL);

            // await fickrTask then parse results with XDocument
            XDocument flickrXML = XDocument.Parse( await flickrTask);

                // Gather  from each photo element in the XML the id, title, secret, server, and farm attributes, then create an object class FlickResult using LINQ.
                //Each FlickrResult contains:
                //A Title property - initialized with the photo element's title attribute
                //a URL property - assembled fromt the photo element's id, secret, server, and farm (a farm is a collection of servers on the Internet) attributes.
                //The format of the URL for each image is specified at 
                //http://www.flickr.com/services/api/misc.urls.html
                var flickrPhotos =
                   from photo in flickrXML.Descendants("photo")
                   let id = photo.Attribute("id").Value
                   let title = photo.Attribute("title").Value
                   let secret = photo.Attribute("secret").Value
                   let server = photo.Attribute("server").Value
                   let farm = photo.Attribute("farm").Value
                select new FlickrResult
               {
                  Title = title,
                  URL = string.Format(
                     "http://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg",
                     farm, server, id, secret )
               };
            imagesListBox.Items.Clear(); // clear imagesListBox
            // set ListBox properties only if results were found
            if ( flickrPhotos.Any() )
            {//Invoke to ToList on the flickrPhotos LINQ query to convert it to list, then assign the result to the ListBox's DataSource property
             //Set the ListBox's DisplayMember property to the Title property.
               imagesListBox.DataSource = flickrPhotos.ToList();
               imagesListBox.DisplayMember = "Title";
            } // end if 
            else // no matches were found
               imagesListBox.Items.Add( "No matches" );
         } // end try
         catch ( WebException ) 
         {
            // check whether Task failed
            if ( flickrTask.Status == TaskStatus.Faulted )
               MessageBox.Show( "Unable to get results from Flickr",
                  "Flickr Error", MessageBoxButtons.OK, 
                  MessageBoxIcon.Error );
            imagesListBox.Items.Clear(); // clear imagesListBox
            imagesListBox.Items.Add( "Error occurred" );
         } // end catch
      } // end method searchButton_Click

      // display selected image
      private async void imagesListBox_SelectedIndexChanged(
         object sender, EventArgs e )
      {
         if ( imagesListBox.SelectedItem != null )
         {
            string selectedURL =
               ( ( FlickrResult ) imagesListBox.SelectedItem ).URL;

                // use WebClient to get selected image's bytes asynchronously
                //Create a WebClient object
                WebClient imageClient = new WebClient();
                //Invoke the the WeClient DownloadDataTaskAsync method to get byte array called imageBytes that contains the photo (from selectedURL) and await the results. 
                byte[] imageBytes = await imageClient.DownloadDataTaskAsync(selectedURL);

                //Create a MemoryStream object from imagesBytes
                MemoryStream memoryStream = new MemoryStream(imageBytes);
                pictureBox.Image = Image.FromStream(memoryStream);
             //Use the Image class's static FromStream method to create an image from the MemoryStream object and assign the image to the PictureBox's image property
             //to display the selected photo
           
         } // end if
      } // end method imagesListBox_SelectedIndexChanged
   } // end class FlickrViewerForm
} // end namespace FlickrViewer

