package apiEngine;

import apiEngine.model.Book;
import apiEngine.model.requests.AddBooksRequest;
import apiEngine.model.requests.AuthorizationRequest;
import apiEngine.model.requests.RemoveBookRequest;
import apiEngine.model.responses.Books;
import apiEngine.model.responses.Token;
import apiEngine.model.responses.UserAccount;
import io.restassured.RestAssured;
import io.restassured.path.json.JsonPath;
import io.restassured.response.Response;
import io.restassured.specification.RequestSpecification;
import org.apache.http.HttpStatus;
import org.apache.http.protocol.HTTP;

public class EndPoints {
    private final RequestSpecification request;
    public EndPoints(String baseURL){
        RestAssured.baseURI = baseURL;
        request = RestAssured.given();
        request.header("Content-Type", "application/json");
    }

    public void authenticateUser(AuthorizationRequest authorizationRequest) {
        Response response =  request.body(authorizationRequest).post(Route.generateToken());
        if (response.getStatusCode() != HttpStatus.SC_OK)
            throw  new RuntimeException("Authentication Failed. Content of failed Response: "
                    + response.toString() + " , Status Code : " + response.statusCode());
        String tokenResponse = JsonPath.from(response.getBody().print()).get("token");
        request.header("Authorization", "Bearer " + tokenResponse);
    }

    public IRestResponse<Books> getBooks() {
        Response response =  request.get(Route.books());
        return new RestResponse(Books.class, response);
    }

    public Response addBook(AddBooksRequest addBooksRequest) {
        Response response =  request.body(addBooksRequest).post(Route.books());
        return response;
    }

    public Response removeBook(RemoveBookRequest removeBookRequest) {
        return request.body(removeBookRequest).delete(Route.book());
    }

    public IRestResponse<UserAccount> getUserAccount(String userId) {
        Response response = request.get(Route.userAccount(userId));
        return new RestResponse(UserAccount.class, response);
    }
}
