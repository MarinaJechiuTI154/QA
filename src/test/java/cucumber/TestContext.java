package cucumber;

import apiEngine.EndPoints;
import enums.Context;
import io.cucumber.java.an.E;

public class TestContext {
    private String BASE_URL = "https://bookstore.toolsqa.com";
    private final String USER_ID = "d10f44f7-a9c3-40ab-af9d-ed2f460c68fa";

    private EndPoints endPoints;
    private ScenarioContext scenarioContext;

    public TestContext(){
        endPoints = new EndPoints(BASE_URL);
        scenarioContext = new ScenarioContext();
        scenarioContext.setScenarioContext(Context.USER_ID, USER_ID);
    }

    public EndPoints getEndPoints(){
        return endPoints;
    }

    public ScenarioContext getScenarioContext(){
        return scenarioContext;
    }
}
