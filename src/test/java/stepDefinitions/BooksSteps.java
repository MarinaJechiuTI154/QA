package stepDefinitions;

import apiEngine.IRestResponse;
import apiEngine.model.Book;
import apiEngine.model.requests.AddBooksRequest;
import apiEngine.model.requests.ISBN;
import apiEngine.model.requests.RemoveBookRequest;
import apiEngine.model.responses.Books;
import apiEngine.model.responses.UserAccount;
import cucumber.TestContext;
import enums.Context;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import io.restassured.path.json.JsonPath;
import io.restassured.response.Response;
import org.junit.Assert;

public class BooksSteps extends BaseSteps {
    private Response response;
    private IRestResponse<UserAccount> userAccountResponse;
    private static IRestResponse<Books> books;


    public BooksSteps(TestContext testContext){
        super(testContext);
    }
    @Given("A list of books are available")
    public void aListOfBooksAreAvailable() {
        IRestResponse<Books> booksResponse = getEndPoints().getBooks();
        Book book = booksResponse.getBody().books.get(0);
        getScenarioContext().setScenarioContext(Context.BOOK, book);
    }

    @When("I add a book to my reading list")
    public void iAddABookToMyReadingList() {
        Book book = (Book) getScenarioContext().getScenarioContext(Context.BOOK);
        String userId = (String) getScenarioContext().getScenarioContext(Context.USER_ID);

        ISBN isbn = new ISBN(book.isbn);
        AddBooksRequest addBooksRequest = new AddBooksRequest(userId, isbn);

        response = getEndPoints().addBook(addBooksRequest);
        getScenarioContext().setScenarioContext(Context.BOOK_ADD_RESPONSE, response.getBody());
    }


    @When("I remove a book from my reading list")
    public void iRemoveABookFromMyReadingList() {
        Book book = (Book) getScenarioContext().getScenarioContext(Context.BOOK);
        String USER_ID = (String) getScenarioContext().getScenarioContext(Context.USER_ID);
        RemoveBookRequest removeBookRequest = new RemoveBookRequest(USER_ID,book.isbn);
        response = getEndPoints().removeBook(removeBookRequest);
        getScenarioContext().setScenarioContext(Context.BOOK_REMOVE_RESPONSE, response);
    }


}
