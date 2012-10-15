using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    public class SerachHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch1C3ProductFilter(string keyWords)
        {
            string serach1C3ProductFilterHTML = String.Empty;

            List<C3ProductSerach1Filter> search1Filters = C3ProductSearchService.GetSearch1C3Names(keyWords);
            if (search1Filters != null)
            {
                StringBuilder strb = new StringBuilder(@"<tbody id='filterTable'><tr>
                    <td class='option' valign='top' width='32' align='right'>
                        分类:
                    </td>
                    <td>
                        <ul>
                            <li class='selected'>全部</li>".Trim());

                string filterItemHTMLTemplate = @"
                            <li>{0}<input type='hidden' value='{1}'/><input type='hidden' value='{2}'/><input type='hidden' value='{3}'/></li>".Trim();

                foreach (C3ProductSerach1Filter filter in search1Filters)
                {
                    strb.Append(String.Format(filterItemHTMLTemplate, filter.C3Name, filter.C1SysNo, filter.C2SysNo, filter.C3SysNo));
                }

                strb.Append(@"</ul>
                    </td>
                </tr></tbody>".Trim());
                serach1C3ProductFilterHTML = strb.ToString();
            }
            return serach1C3ProductFilterHTML;
        }



    }
}
