import styles from './homeStyles.module.scss'

export default function HomeComponent() {
    return (
        <div className={styles.welcomeContainer}>
            <h1>Bienvenido al Sistema Integral de Gestión</h1>
            <p>Optimizando procesos para un mejor rendimiento.</p>
        </div>
    )
}