package cucumber;

import apiEngine.EndPoints;
import dataProvider.ConfigReader;
import enums.Context;
import io.cucumber.java.an.E;

public class TestContext {
    private EndPoints endPoints;
    private ScenarioContext scenarioContext;

    public TestContext(){
        endPoints = new EndPoints(ConfigReader.getInstance().getBaseUrl());
        scenarioContext = new ScenarioContext();
        scenarioContext.setScenarioContext(Context.USER_ID, ConfigReader.getInstance().getUserId());
    }

    public EndPoints getEndPoints(){
        return endPoints;
    }

    public ScenarioContext getScenarioContext(){
        return scenarioContext;
    }
}
