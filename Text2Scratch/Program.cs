using System.Text;
using Text2Scratch.ScratchObjects;


try{
    
    //Your script here
    
    ScratchObjectManager scratchObjectManager;
    scratchObjectManager = new ScratchObjectManager();
    
    ScratchSprite testSprite = scratchObjectManager.AddSprite("TestSprite");
    
    ScratchVariable cloudVar = scratchObjectManager.AddCloudVariable("TestCloud", 323);
    scratchObjectManager.AddMonitor(cloudVar, false, 200, 200);
    

    
    ScratchVariable datav = scratchObjectManager.AddGlobalVariable("datav");
    scratchObjectManager.AddMonitor(datav, false, 0, 0);

    ScratchScriptCreator sc = new ScratchScriptCreator(scratchObjectManager, 0, 0);
    {
        sc.WhenFlagClicked();
        sc.SetVariableTo(datav, 0);
        testSprite.AddComment( sc.BeginRepeat(5),"ASDASDASDAS");
        {
            sc.WaitSeconds(1);
            sc.ChangeVariableBy(datav, 1);
            sc.BeginIfElse(sc.Equals(datav, 3));
            sc.Say("aaaaa");
            sc.EndCblock();
            sc.Say("");
            sc.EndCblock();
        }
        sc.EndCblock();
    }
    sc.AddScriptToSprite(testSprite);
      
    scratchObjectManager.AddMonitor(testSprite.AddList("testList",new object[] {"hihi","haha" }), 100, 100, 100, 200);
  

    ScratchCostume catCostume = new ScratchCostume(@"Assets\Costumes\Cat-a.svg", "Cat", 0, 0);
    testSprite.AddCostume(catCostume);
    
    ScratchScriptCreator scc = new ScratchScriptCreator(scratchObjectManager, 0, 800);
    {
        scc.WhenFlagClicked();
        scc.BeginForever();
        {
            scc.PointTowards(PointTowards.Mouse);
            scc.MoveSteps(10);
        }
        scc.EndCblock();
    }
    scc.AddScriptToSprite(testSprite);
   
    ScratchCustomBlock customBlock;

    ScratchScriptCreator sc2=new ScratchScriptCreator(scratchObjectManager, 0, 0);
    {
        CBArgBool ifVal = new CBArgBool("ifVal");
        CBArgNumString valTrue = new CBArgNumString("valTrue");
        CBArgNumString valFalse = new CBArgNumString("valFalse");

        customBlock = new ScratchCustomBlock(true, "Set if", ifVal, "to", valTrue, "else", valFalse);

        
        sc2.DefineCustomBlock(customBlock);
        
        sc2.Say(ifVal);
        sc2.Say(valTrue);



    }
    sc2.AddScriptToSprite(testSprite);
    
    
    ScratchScriptCreator sc3 = new ScratchScriptCreator(scratchObjectManager, 400, 0);
    {
        testSprite.AddComment(sc3.WhenFlagClicked(), "Hello\nHAHAH");
        sc3.CallCustomBlock(customBlock, sc3.KeyPressed(KeyCode.Space), 10, -10);
        sc3.BeginIf(false);
        sc3.PlayNote(43, 50);
        sc3.PlayDrum(Drum.CrashCymbal, 44);
        sc3.Stop(StopOption.ThisScript);
        sc3.EndCblock();
        sc3.Stop(StopOption.ThisScript);

    }
    sc3.AddScriptToSprite(testSprite);
    

    ScratchProjectBuilder.GenerateProject(scratchObjectManager, "thing");
}
catch(ScratchException e){
    Console.WriteLine("Project failed to build: " + e.Message);
    throw;
}
