package apiEngine;

import io.restassured.response.Response;

public class RestResponse<T> implements IRestResponse<T>{
    private T data;
    private Response response;
    private Exception e;

    public RestResponse(Class<T> t, Response response){
        this.response = response;
        try {
            this.data = t.newInstance();
        } catch (Exception e){
            throw  new RuntimeException("There should be a default constructor in the Response POJO");
        }
    }
    public T getBody() {
       try {
           data = (T)response.getBody().as(data.getClass());
       } catch (Exception e){
           this.e = e;
       }
       return data;
    }

    public String getContent() {
        return response.body().asString();
    }

    public int getStatusCode() {
        return response.getStatusCode();
    }

    public boolean isSuccessful() {
        int statusCode = response.getStatusCode();
        if(200<=statusCode && statusCode<=205){
            return true;
        }
        return  false;
    }

    public String getStatusDescription() {
        return response.getStatusLine();
    }

    public Response getResponse() {
        return this.response;
    }

    public Exception getException() {
        return e;
    }
}
