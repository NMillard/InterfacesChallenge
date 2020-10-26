using System.ComponentModel.DataAnnotations;

namespace InterfacesChallenge.WebClient.Authors.RequestInputs {
    public class BeginArticleInput {
        [Required] public string PenName { get; set; }
        [Required] public string ArticleTitle { get; set; }
    }
}