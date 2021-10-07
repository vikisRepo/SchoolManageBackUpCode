import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent, HttpResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AnyARecord } from 'dns';
import { catchError, retry } from 'rxjs/operators';
  
@Injectable(
 {providedIn:'root'}
)
export class UploadDownloadService {
  private baseApiUrl: string;
  private apiDownloadUrl: string;
  private apiUploadUrl: string;
  private apiFileUrl: string;
  private apiStudentUploadUrl : string;
  private studocsapiURL : string;
  
  constructor(private httpClient: HttpClient) {
    this.baseApiUrl = environment.apiUrl + '/api/UploadDownload';
    this.apiDownloadUrl = this.baseApiUrl + '/download';
    this.apiUploadUrl = this.baseApiUrl + '/api/upload';
    this.studocsapiURL = environment.apiUrl + '/api/UploadDownload/GetStudentDocumentDetails';
    
    this.apiFileUrl = this.baseApiUrl + '/files';
  }

  GetStudentDocumentDetails(admissionNumber : any, docType : any): Observable<any> {
    return this.httpClient.get<any>(this.studocsapiURL + '/' + admissionNumber + '/' + docType)
    .pipe(
      retry(1)
    )
  }  
  
  public downloadFile(file: string): Observable<HttpEvent<Blob>> {
    
    return this.httpClient.request(new HttpRequest(
      'GET',
      `${this.apiDownloadUrl}?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  
  
  public uploadFile(file: Blob, docdetails : any): Observable<HttpEvent<void>> {
    debugger;
    const formData = new FormData();
    formData.append('file', file);
    // formData.append('studentAttachments', JSON.stringify(docdetails));
    formData.append('admissionNumber', docdetails.admissionNumber);
    formData.append('documentType', docdetails.documentType);
    formData.append('pathToFile', '');
    this.apiStudentUploadUrl = environment.apiUrl + '/api/UploadDownload/UploadStudentDocument'; 
    let stuparams= new HttpParams()
    stuparams.set('admissionNumber', docdetails.admissionNumber);
    stuparams.set('documentType', docdetails.documentType);
    stuparams.set('pathToFile', '');
    return this.httpClient.request(new HttpRequest(
      'POST',
      this.apiStudentUploadUrl,
      formData,
      {
        reportProgress: true,
        params: stuparams
      }));
  }
  
  public getFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiFileUrl);
  }
}