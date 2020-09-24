package stepDefinitions;

import apiEngine.EndPoints;
import apiEngine.model.requests.AuthorizationRequest;
import cucumber.TestContext;
import io.cucumber.java.en.Given;

public class AccountSteps extends BaseSteps{

    private static final String USERNAME = "marina";
    private static final String PASSWORD = "Marina@95";
    public AccountSteps(TestContext testContext){
        super(testContext);
    }
    @Given("I am an authorized user")
    public void iAmAnAuthorizedUser() {
        AuthorizationRequest authorizationRequest = new AuthorizationRequest(USERNAME, PASSWORD);
        getEndPoints().authenticateUser(authorizationRequest);
    }
}
