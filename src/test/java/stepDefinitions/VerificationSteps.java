package stepDefinitions;

import apiEngine.IRestResponse;
import apiEngine.RestResponse;
import apiEngine.model.Book;
import apiEngine.model.responses.UserAccount;
import cucumber.ScenarioContext;
import cucumber.TestContext;
import enums.Context;
import io.cucumber.java.en.Then;
import io.restassured.path.json.JsonPath;
import io.restassured.response.Response;
import org.junit.Assert;

import java.io.File;

import static enums.Context.USER_ID;

public class VerificationSteps extends BaseSteps {

    public VerificationSteps(TestContext testContext){
        super(testContext);
    }

    @Then("the book is added")
    public void theBookIsAdded() {
        Response response = (Response) getScenarioContext().getScenarioContext(Context.BOOK_ADD_RESPONSE);
        Assert.assertEquals(201, response.getStatusCode());
        String isbn =  JsonPath.from(response.getBody().print()).get("books[0].isbn");
        Book book = (Book) getScenarioContext().getScenarioContext(Context.BOOK);
        Assert.assertEquals(isbn, book.isbn);
    }


    @Then("the book is removed")
    public void theBookIsRemoved() {
        String userId = (String) getScenarioContext().getScenarioContext(Context.USER_ID);
        Response response = (Response) getScenarioContext().getScenarioContext(Context.BOOK_REMOVE_RESPONSE);

        Assert.assertEquals(204, response.getStatusCode());
        IRestResponse<UserAccount> userAccountRestResponse = getEndPoints().getUserAccount(userId);

        Assert.assertEquals(200, userAccountRestResponse.getStatusCode());
        Assert.assertEquals(0, userAccountRestResponse.getBody().books.size());
    }
}
