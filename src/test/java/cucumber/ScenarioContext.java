package cucumber;

import enums.Context;

import java.util.HashMap;
import java.util.Map;

public class ScenarioContext {
    private Map<String, Object> scenarioContext;

    public ScenarioContext(){
        scenarioContext = new HashMap<String, Object>();
    }

    public void setScenarioContext(Context key, Object value){
        scenarioContext.put(key.toString(), value);
    }

    public Object getScenarioContext(Context key){
        return scenarioContext.get(key.toString());
    }

    public Boolean isContains(Context key){
        return scenarioContext.containsKey(key.toString());
    }
}
