import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OpeaWebService } from './opea.web.service';

var apiUrl = "https://localhost:7202/";

var httpLink = {
  getAllClient: apiUrl + "/api/client",
  getByIdClient: apiUrl + "/api/client",
  createClient: apiUrl + "/api/client",
  updateClient: apiUrl + "/api/client",
  deleteClient: apiUrl + "/api/client"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: OpeaWebService) { }

  public getAllClient(): Observable<any> {
    return this.webApiService.get(httpLink.getAllClient);
  }
  public getByIdClient(model: any): Observable<any> {
    return this.webApiService.get(httpLink.getByIdClient + '/' + model);
  }
  public createClient(model: any): Observable<any> {
    return this.webApiService.post(httpLink.createClient, model);
  }
  public updateClient(model: any): Observable<any> {
    return this.webApiService.post(httpLink.updateClient, model);
  }  
  public deleteClient(model: any): Observable<any> {
    return this.webApiService.post(httpLink.deleteClient + "/" + model, "");
  }  
}
