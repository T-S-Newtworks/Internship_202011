using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace seamark.Models
{
  public class article
  {

  
      [DisplayName("投稿日時")]
    [DisplayFormat(DataFormatString = "{0:MM月dd日HH時mm分}")]
    public DateTime Date { get; set; }
    [DisplayName("解決済みフラグ")]
    public Boolean Solveflag { get; set; }
    [DisplayName("名前")]
    public String Name { get; set; }
    [DisplayName("削除フラグ")]
    public Boolean Deleteflag { get; set; }
    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("記事")]
    public String Text { get; set; }
    [DisplayName("ハイライトフラグ")]
    public Boolean Highlightflag { get; set; }

    [DisplayName("アカウント")]
    public virtual Account Account{ get; set; }

    //[DisplayName("ハイライトメッセージ")]
    //public virtual highlights Highlight { get; set; }

    [DisplayName("投票")]
    public virtual Vote Vote { get; set; }

    [DisplayName("コメント")]
    public virtual ICollection<Comment> Comments{ get; set; }
  }
}