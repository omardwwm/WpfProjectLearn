using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfProjetFinal.Commandes;
using WpfProjetFinal.Models;
using Newtonsoft.Json;
using WpfProjetFinal.Helpers;
using System.Windows.Media;
using Microsoft.Win32;
using System.Diagnostics;
using System.ComponentModel;

namespace WpfProjetFinal.ViewModel
{
    public class UserViewModel : IDisposable, INotifyPropertyChanged
    {
        static HttpClient client = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged;

        public void JaiChange(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public User UserVM { get; set; }

        //Gerer l'image
        private string _PictureVM;
        public string PictureVM { get { return _PictureVM; } set { _PictureVM = value; JaiChange("PictureVM"); } }

        public ObservableCollection<User> UsersVM { get; set; }
        //public List<User> UsersVM { get; set; }

        // Les images

        //private string _imagePath = string.Empty;
        //public object ImagePath
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_imagePath))
        //            return DependencyProperty.UnsetValue;

        //        return _imagePath;
        //    }
        //    set
        //    {
        //        if (!(value is string))
        //            return;

        //        _imagePath = value.ToString();
        //        JaiChange("ImagePath");
        //    }
        //}

        private User _UserSellectionedVM;
        public User UserSellectionedVM { 
            get { return _UserSellectionedVM; } 
            set { _UserSellectionedVM = value;
                JaiChange(nameof(UserSellectionedVM));
                //JaiChange("UserSellectionedVM");
            } 
        }

        //public AddUser AddUserVM { get; set; }

        //public GetUsers GetUsersVM { get; set; }

        //public DeleteUser DeleteUser { get; set; }
        public UserViewModel()
        {
            UserVM = new User();

            //AddUserVM = new AddUser(this);

            //GetUsersVM = new GetUsers(this);

            //UsersVM = new ObservableCollection<User>();
            //UsersVM = new List<User>();
            UsersVM = new ObservableCollection<User>();

            UserSellectionedVM = new User();
            PictureVM = UserSellectionedVM.Picture;

        }
        

        public async Task<User> AddUserWS(User userVM)
        {
            // userTest pour tester sans binding
            //var userTest = new User() { Id = "fromWpf", Nom="wpfNom", Email="wpf.mail@email.com", Password="wpfPassword", Picture="wpfPict.jpeg"};
            client.BaseAddress = new Uri("http://localhost:88/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            UserVM.Id = Guid.NewGuid().ToString();
            UserVM.Password = CryptHelper.Base64Encode(UserVM.Password); //encoder le password avant send it to db.
            //UserVM.Picture = "testPic.jpg";
            HttpResponseMessage response = await client.PostAsJsonAsync("api/users", UserVM);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<User>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }


        //public async Task<IEnumerable<User>> GetUsersWS()
        public async Task<IEnumerable<User>> DawnloadUsers()
        {
            //UsersVM = new ObservableCollection<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:88/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/users").ConfigureAwait(false);
            Debug.WriteLine(response.StatusCode + "le status code est : ");
            if (response.IsSuccessStatusCode)
            {
                //Debug.WriteLine(response.IsSuccessStatusCode + "le status code est : ");
                var jsonString = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine("Le stringJson ===> " +jsonString);
                //var users = await response.Content.ReadAsAsync<IEnumerable<User>>();
                var users = JsonConvert.DeserializeObject<List<User>>(jsonString);
                //MessageBox.Show("Afficher Users");
                //Debug.WriteLine("utilisateur ===========>>>>>> ");
               
                //grdUser.ItemsSource = users;
                //UsersVM = users;
                //UsersVM = new ObservableCollection<User>(users);
                //UsersVM.ToList().ForEach(x => Debug.WriteLine("Email is =========================>" + x.Email));
                //Debug.Write("TYPE OF USERSVM IS==============================> "+ users.GetType());
                //MessageBox.Show("Fin du IF");
                //return UsersVM;
                return new List<User>(users);

            }
            else
            {
                Debug.WriteLine(response.StatusCode + "le status code est : ");
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                return null;
            }

        }
        public async void GetUsersWS()
        {
            var userstmp = await DawnloadUsers();
            UsersVM.Clear();
            foreach (var user in userstmp)
            {
                UsersVM.Add(user);
            }
        }

        //A revoir... Ajouter la condition if user loggedIn
        //public async Task<User> getOneUser(string userId)
        //{
        //    client.BaseAddress = new Uri("http://localhost:88/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = client.GetAsync($"api/users/{UserSellectionedVM.Id}").Result;
        //    User user = null;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        user = await response.Content.ReadAsAsync<User>(); // Autre facon de Desrialiser sans passer par deserializsObject (ex: les deux lignes suivate dans ce code)
        //        //var jsonString = await response.Content.ReadAsStringAsync();
        //        //var user = JsonConvert.DeserializeObject<User>(jsonString);
        //        //return user;
        //        UserSellectionedVM = user;
        //    }

        //    return UserSellectionedVM;
        //}



        public void Dispose()
        {
            client.Dispose();
        }
    }
}
