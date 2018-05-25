using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMarketView : ViewManager {

    public Dropdown Drop;
    public ScrollManager ScrollManager;
    public TreeViewControl TreeView;
   // public ScrollRect ScrollRect;


    public override void StartInterface()
    {
        WebServices.GetItemByCategory(6, OnSucess);

        Drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Drop);
        });

       // ScrollRect.onValueChanged.AddListener(ScrollManagerValueChanged);
    }

    public override void ExitInterface()
    {
        MenuFlow.Instance.ChangeState(MenuFlow.GameState.STATE_None);
    }



    void OnSucess(List<VoGroup> ListItem)
    {



         List<TreeViewData> datas = new List<TreeViewData>();
         TreeViewData data = new TreeViewData();
         data.Name = "Magasin";
         data.ParentID = -1;
         datas.Add(data);


         for ( int i =0; i <ListItem.Count; i++)
         {
             data = new TreeViewData();
             data.Name = ListItem[i].label;             
             data.ParentID = 0;
             datas.Add(data);
         }

        for (int i = 0; i < ListItem.Count; i++)
        {
            foreach (VoItem item in ListItem[i].ListItem)
            {                
                data = new TreeViewData();
                data.Name = item.label;
                data.ParentID = i+1;
                datas.Add(data);
            }
        }


        TreeView.Data = datas;


        TreeView.GenerateTreeView();
        //刷新树形菜单  
        TreeView.RefreshTreeView();



        TreeView.ClickItemEvent += CallBack;




        Drop.ClearOptions();
        List<string> ListDrop = new List<string>();
        foreach (VoGroup Group in ListItem)
        {
            ListDrop.Add(Group.label);

            /*   Debug.Log("OnSucess" + ListItem.Count + "---" + AManager.instance.ListVoItem.Count);
               foreach (VoItem item in Group.ListItem)
               {
                   StartCoroutine(setImage(item));
               }*/


        }

        Drop.AddOptions(ListDrop);

        ScrollManager.GenerateScroll(AManager.instance.ListItem[0].ListItem);

    }

    
  
    void CallBack(GameObject item)
    {
        Debug.Log(item.name);
    }


    void DropdownValueChanged(Dropdown change)
    {
        ScrollManager.GenerateScroll(AManager.instance.ListItem[change.value].ListItem);
        Debug.Log("New Value : " + AManager.instance.ListItem[change.value].label);
    }


    #region function called by button

    public void LoadShipItems()
    {
        WebServices.GetItemByCategory(6, OnSucess);
    }

    public void LoadModulesItems()
    {
        WebServices.GetItemByCategory(7, OnSucess);
    }


    #endregion


}
