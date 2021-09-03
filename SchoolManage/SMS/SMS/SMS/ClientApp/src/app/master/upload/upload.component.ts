import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  imgPath;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
   
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post('api/api/upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe((event:any) => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          console.log(fileToUpload.type);
          if(fileToUpload.type==='application/pdf'){
            this.imgPath='PDF';
          }else{
          this.imgPath = `api/api/${event.body.dbPath}` ;
          }
          this.onUploadFinished.emit(event.body);
        }
      });
  }

  
}