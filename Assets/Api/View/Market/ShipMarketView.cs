using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMarketView : ViewManager {

    //public Dropdown Drop;


    //public ScrollManager ScrollManager;
    public TreeViewControl TreeView;
    public DataBind DetailsView;

    public Transform Spawn;


    public override void StartInterface()
    {


        /* Debug.Log(AManager.Instance.user.id);
         Debug.Log(AManager.Instance.user.spaceship.id);
         Instantiate(Resources.Load(AManager.Instance.user.spaceship.url),Vector3.zero, Quaternion.Euler(0.0f,0.0f,0.0f) ,Spawn);
         Spawn.transform.localScale = new Vector3(Spawn.transform.localScale.x*6.0f, Spawn.transform.localScale.y * 6.0f, Spawn.transform.localScale.z * 6.0f); 
         */
        //Resources.Load("Prefabs/");
        int[] id = new int[1];
        id[0] = 7;
        WebServices.LoadMarketById(id, null, OnSucess);
        //LoadingTreeView(AManager.Instance.GetModuleCategories().ListGroup);
       
        
        
        
        /* Drop.onValueChanged.AddListener(delegate {
             DropdownValueChanged(Drop);
         });*/

        // ScrollRect.onValueChanged.AddListener(ScrollManagerValueChanged);



    }

    public void OnSucess()
    {
        Debug.Log(AManager.Instance.GetModuleCategories().ListGroup.Count);
        LoadingTreeView(AManager.Instance.GetModuleCategories().ListGroup);
    }

    public override void ExitInterface()
    {
        MenuFlow.Instance.ChangeState(MenuFlow.GameState.STATE_None);
    }



    void LoadingTreeView(List<VoGroup> ListItem)
    {

        Debug.Log("LoadingTreeView : " + ListItem.Count);

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
                data.item = item;
                datas.Add(data);
            }
        }


        TreeView.Data = datas;


        TreeView.GenerateTreeView();
        //刷新树形菜单  
        TreeView.RefreshTreeView();



        TreeView.ClickItemEvent += CallBack;




  //      Drop.ClearOptions();
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

   //     Drop.AddOptions(ListDrop);

  //      ScrollManager.GenerateScroll(AManager.instance.ListItem[0].ListItem);

    }

    
  
    void CallBack(TreeViewData data)
    {       
        if (data != null && data.item != null)
        {
            Debug.Log(data.item.id);
            Debug.Log(data.item.label);
            DetailsView.SetData(data.item);
        }
        
       
    }


   /* void DropdownValueChanged(Dropdown change)
    {
        ScrollManager.GenerateScroll(AManager.instance.ListItem[change.value].ListItem);
        Debug.Log("New Value : " + AManager.instance.ListItem[change.value].label);
    }*/


    #region function called by button

    public void LoadShipItems()
    {

        LoadingTreeView(AManager.Instance.GetShipCategories().ListGroup);
        //WebServices.GetItemByCategory(6, OnSucess);
    }

    public void LoadModulesItems()
    {
        LoadingTreeView(AManager.Instance.GetModuleCategories().ListGroup);
        //WebServices.GetItemByCategory(7, OnSucess);
    }
    

    public void Buy()
    {
        Debug.Log(DetailsView.GetData().id);
        WebServices.BuyItem(DetailsView.GetData().id);
    }
    #endregion


}
