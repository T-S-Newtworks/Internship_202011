using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace seamark.Models
{
  public class Account
  {
    [DisplayName("職位")]
    public string　Position { get; set; }

    [DisplayName("削除フラグ")]
    public Boolean AccountisDeleted { get; set; }
   
    [DisplayName("権限")]
    public string Authority { get; set; }

    [DisplayName("名前")]
    public string Name { get; set; }

    [DisplayName("出身地")]
    public string From { get; set; } 
    

    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("記事")]
    public virtual ICollection<article> Articles { get; set; }

    [DisplayName("投票")]
    public virtual ICollection<Vote> Votes { get; set; }

    //[DisplayName("ハイライトメッセージ")]
    //public virtual ICollection<highlights> Highlights { get; set; }
  }
}