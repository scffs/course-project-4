using System.Text.Json.Serialization;

namespace UserPanel.Models.Request
{
    public class RegisterReguest(string UserName, string UserSurname, string UserPatronymic, bool Sex, DateTime Birthday, string Login, string Password, string Avatar_Url)
    {
        [JsonPropertyName("name")]
        public string UserName { get; set; } = UserName ?? throw new ArgumentNullException(nameof(UserName));

        [JsonPropertyName("surname")]
        public string UserSurname { get; set; } = UserSurname ?? throw new ArgumentNullException(nameof(UserSurname));
        
        [JsonPropertyName("patronymic")]
        public string UserPatronymic { get; set; } = UserPatronymic ?? throw new ArgumentNullException(nameof(UserPatronymic));

        [JsonPropertyName("sex")]
        public bool Sex { get; set; } = Sex /*?? throw new ArgumentNullException(nameof(sex))*/;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; } = Birthday/* ?? throw new ArgumentNullException(nameof(Birthday))*/;

        [JsonPropertyName("login")]
        public string Login { get; set; } = Login ?? throw new ArgumentNullException(nameof(Login));

        [JsonPropertyName("password")]
        public string Password { get; set; } = Password ?? throw new ArgumentNullException(nameof(Password));

        [JsonPropertyName("avatar_url")]
        public string Avatar_Url { get; set; } = Avatar_Url ?? throw new ArgumentNullException(nameof(Avatar_Url));

    }
}
