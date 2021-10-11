using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seamark.Models
{
  public class highlights
  {
    [DisplayName("投稿日時")]
    [DisplayFormat(DataFormatString = "{0:MM月DD日HH時MM分}")]
    public DateTime Date { get; set; }
    [DisplayName("名前")]
    public String Name { get; set; }

    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("記事")]
    public String Text { get; set; }

    [DisplayName("削除フラグ")]
    public Boolean Deleteflag { get; set; }

    [DisplayName("色")]
    public int Color { get; set; }

    //[DisplayName("アカウント")]
    //public virtual account Account { get; set; }

    //[DisplayName("記事")]
    //public virtual article Article { get; set; }
  }
}