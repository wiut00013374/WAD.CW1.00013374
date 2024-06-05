import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../../services/car.service';
import { Car } from '../../models/car';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule] 
})
export class CarDetailComponent implements OnInit {
  carForm: FormGroup;
  carId: number | null = null; 

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private carService: CarService,
    private fb: FormBuilder
  ) {
    this.carForm = this.fb.group({
      vehicleBrand: ['', Validators.required],
      vehicleModel: ['', Validators.required],
      manufactureYear: ['', Validators.required],
      vehicleColor: ['', Validators.required],
      clientId: ['']
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.carId = +id;  
        this.carService.getCar(this.carId).subscribe((car) => {
          this.carForm.patchValue(car);
        });
      }
    });
  }

  onSubmit(): void {
    if (this.carId) {
      this.carService.updateCar(this.carId, this.carForm.value).subscribe(() => {
        this.router.navigate(['/cars']);
      });
    } else {
      this.carService.createCar(this.carForm.value).subscribe(() => {
        this.router.navigate(['/cars']);
      });
    }
  }
}
